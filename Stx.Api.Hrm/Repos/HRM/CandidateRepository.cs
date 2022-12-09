using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stx.Api.Hrm.Configurations;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Api.Hrm.Interfaces.Services;
using Stx.Shared.Api.Interfaces;
using Stx.Shared.Constants;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Repos.HRM
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly IBlobStorageService _blobStorageService;
        private readonly ICdnFileService _cdnFileService;
        private readonly AzureStorageConfiguration _azureBlobStorageConfig = null;

        public CandidateRepository(StxDbContext appDbContext,
            IBlobStorageService blobStorageService,
            ICdnFileService cdnFileService,
            IOptionsMonitor<AzureStorageConfiguration> config,
            ILogger<CandidateRepository> logger)
        {
            _blobStorageService = blobStorageService;
            _cdnFileService = cdnFileService;
            _appDbContext = appDbContext;
            _azureBlobStorageConfig = config.CurrentValue;

        }

        public List<HrCandidate> GetAllRecords()
		{
            return _appDbContext.HrCandidates.OrderByDescending(x=> x.CandidateID).Take(50).ToList();
        }

        public HrCandidate GetRecordByID(int id)
		{
            return _appDbContext.HrCandidates.Where(c => c.CandidateID == id)
                .Include(i=> i.Certificates)
                .Include(p => p.Educations)
                .Include(p => p.Experiences)
                .Include(p => p.Skills)
                .Include(p => p.Languages)
                .FirstOrDefault();
        }   
        
        public HrCandidate GetPublicCandidate(int id)
		{
            var cand = GetRecordByID(id);
            cand.DateOfBirth = null;
            cand.Disability = null;
            cand.ExternalID = null;
            cand.IsMassMailOptOut = null;
            cand.IsMessengerOptIn = null;
            cand.IsSmsOptIn = null;
            cand.IsWhatsappOptIn= null;
            cand.LinkedCorpContact= null;
            cand.MaritalStatus = null;
            cand.Owner = null;
            cand.Placements = null;
            cand.UserName = null;

            cand.Educations.RemoveAll(x => x.Active != true);
            cand.Experiences.RemoveAll(x => x.Active != true);
            cand.Certificates.RemoveAll(x => x.Active != true);

            if (cand.Privacy == 1)
            {
                cand.Experiences.ForEach(x => { x.Salary = null; x.TerminationReason = null; x.CorporateID = 0; x.Commission = 0; x.Bonus = 0; });
            }
            return cand;
        }

        public HrCandidate GetRecordByCD(string code)
		{
            return _appDbContext.HrCandidates.Where(c => c.UserName == code)
                .Include(i=> i.Certificates)
                .Include(p => p.Educations)
                .Include(p => p.Experiences)
                .Include(p => p.Skills)
                .Include(p => p.Languages)
                .FirstOrDefault();
        }  
        
        public List<HrCandidateJobStatDTO> GetCandidateJobStats(int candidateId, string listCode)
        {
            string qry = $"EXEC [HRMCandidateJobStatSearch] @CandidateID={candidateId}, @ListType='{listCode}'";
            return _appDbContext.Set<HrCandidateJobStatDTO>().FromSqlRaw(qry).AsEnumerable().ToList();
        }    

        public HrCandidate UpdateRecord(HrCandidate entry, EntryState entryState, string userId)
		{
            if (entryState == EntryState.New)
            {
                var addedEntity = _appDbContext.HrCandidates.Add(entry);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            else
			{
                _appDbContext.HrCandidates.Add(entry);
                _appDbContext.Entry(entry).State = EntityState.Modified;

                entry.Certificates.ToList().ForEach(x => _appDbContext.Entry(x).State = x.ID > 0 ? EntityState.Modified: EntityState.Added);
                entry.Educations.ToList().ForEach(x => _appDbContext.Entry(x).State = x.ID > 0 ? EntityState.Modified : EntityState.Added);
                entry.Experiences.ToList().ForEach(x => _appDbContext.Entry(x).State = x.ID > 0 ? EntityState.Modified : EntityState.Added);

                _appDbContext.SaveChanges();

                var entryToUpdate = _appDbContext.HrCandidates.FirstOrDefault(e => e.CandidateID == entry.CandidateID);

                if (entryToUpdate != null)
                {
                    entryToUpdate.MaritalStatus = entry.MaritalStatus;
                    entryToUpdate.Email = entry.Email;
                    entryToUpdate.FirstName = entry.FirstName;
                    entryToUpdate.LastName = entry.LastName;
                    entryToUpdate.Gender = entry.Gender;

                    return entryToUpdate;
                }

                return null;
            }
        }

        public HrCandidate PartialUpdateRecord(HrCandidate entry, string updateDivCode, string userId)
        {
            var entryToUpdate = _appDbContext.HrCandidates.FirstOrDefault(e => e.CandidateID == entry.CandidateID);
            if (entryToUpdate == null)
            {
                return null;
            }

            if (updateDivCode.Compare("Resume_Additional_Info"))
            {
                entryToUpdate.SkillSetDesc = entry.SkillSetDesc;
                entryToUpdate.ExpectedSalary = entry.ExpectedSalary;
                entryToUpdate.Comments = entry.Comments;
                entryToUpdate.DateLastModified = DateTime.UtcNow;

                _appDbContext.HrCandidates.Add(entryToUpdate);
                _appDbContext.Entry(entryToUpdate).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                var sentryToUpdate = _appDbContext.HrCandidates.FirstOrDefault(e => e.CandidateID == entry.CandidateID);
                return entryToUpdate;
            }

            return null;
        }


        public List<HrCandidateExperience> GetExperiences(int candidateId, int recId)
        {
            if(recId > 0)
                return _appDbContext.HrCandidateExperiences.Where(e => e.CandidateID == candidateId && e.ID == recId).ToList();
            else 
                return _appDbContext.HrCandidateExperiences.Where(e => e.CandidateID == candidateId).ToList();
        }

        public List<HrCandidateEducation> GetEducations(int candidateId, int recId)
        {
            if (recId > 0)
                return _appDbContext.HrCandidateEducations.Where(e => e.CandidateID == candidateId && e.ID == recId).ToList();
            else 
                return _appDbContext.HrCandidateEducations.Where(e => e.CandidateID == candidateId).ToList();
        }

        public List<HrCandidateCertificate> GetCertificates(int candidateId, int recId)
        {
            if (recId > 0)
                return _appDbContext.HrCandidateCertificates.Where(e => e.CandidateID == candidateId && e.ID == recId).ToList();
            else
                return _appDbContext.HrCandidateCertificates.Where(e => e.CandidateID == candidateId).ToList();
        }

        public List<HrCandidateSkill> GetSkills(int candidateId, int recId)
        {
            if (recId > 0)
                return _appDbContext.HrCandidateSkills.Where(e => e.CandidateID == candidateId && e.ID == recId).ToList();
            else
                return _appDbContext.HrCandidateSkills.Where(e => e.CandidateID == candidateId).ToList();
        }

        public List<HrCandidateLanguage> GetLanguages(int candidateId, int recId)
        {
            if (recId > 0)
                return _appDbContext.HrCandidateLanguages.Where(e => e.CandidateID == candidateId && e.ID == recId).ToList();
            else
                return _appDbContext.HrCandidateLanguages.Where(e => e.CandidateID == candidateId).ToList();
        }

        public HrCandidateExperience UpdateExperiences(HrCandidateExperience entry)
        {
            if (entry.ID < 0)
            {
                entry.ID = 0;
                var addedEntity = _appDbContext.HrCandidateExperiences.Add(entry);
                _appDbContext.Entry(entry).State = EntityState.Added;
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            else
            {
                _appDbContext.HrCandidateExperiences.Add(entry);
                _appDbContext.Entry(entry).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                return _appDbContext.HrCandidateExperiences.FirstOrDefault(e => e.ID == entry.ID && e.CandidateID == entry.CandidateID);
            }
        }
        public HrCandidateEducation UpdateEducations(HrCandidateEducation entry)
        {
            if (entry.ID < 0)
            {
                entry.ID = 0;
                var addedEntity = _appDbContext.HrCandidateEducations.Add(entry);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            else
            {
                _appDbContext.HrCandidateEducations.Add(entry);
                _appDbContext.Entry(entry).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                return _appDbContext.HrCandidateEducations.FirstOrDefault(e => e.ID == entry.ID && e.CandidateID == entry.CandidateID);
            }
        }
        public HrCandidateCertificate UpdateCertificates(HrCandidateCertificate entry)
        {
            if (entry.ID < 0)
            {
                entry.ID = 0;
                var addedEntity = _appDbContext.HrCandidateCertificates.Add(entry);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            else
            {
                _appDbContext.HrCandidateCertificates.Add(entry);
                _appDbContext.Entry(entry).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                return _appDbContext.HrCandidateCertificates.FirstOrDefault(e => e.ID == entry.ID && e.CandidateID == entry.CandidateID);
            }
        }

        public List<HrCandidateSkill> UpdateSkills(List<HrCandidateSkill> entries)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    var list = _appDbContext.HrCandidateSkills.Where(x => x.CandidateID == entries.First().CandidateID).AsNoTracking().ToList();

                    var listDelete = list.Where(x => !entries.Where(y => y.ID > 0).Select(x => x.ID).Distinct().Contains(x.ID));
                    if (listDelete != null && listDelete.Count() > 0)
                    {
                        _appDbContext.HrCandidateSkills.RemoveRange(listDelete);
                        _appDbContext.SaveChanges();
                    }

                    foreach (var item in entries)
                    {
                        var dbRec = list.Where(x => x.ID == item.ID).FirstOrDefault();
                        if (dbRec == null) //new
                        {
                            item.ID = default;
                        }
                        item.DateLastModified = DateTime.UtcNow;
                        item.UserModified = entries.FirstOrDefault().UserModified;
                        item.SkillType = "G";

                        _appDbContext.HrCandidateSkills.Add(item);
                        _appDbContext.Entry(item).State = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    }
                    _appDbContext.SaveChanges();
                    transaction.Commit();

                    return _appDbContext.HrCandidateSkills.Where(x => x.CandidateID == entries.First().CandidateID).AsNoTracking().ToList();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<HrCandidateLanguage> UpdateLanguages(List<HrCandidateLanguage> entries)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    var list = _appDbContext.HrCandidateLanguages.Where(x => x.CandidateID == entries.First().CandidateID).AsNoTracking().ToList();

                    var listDelete = list.Where(x => !entries.Where(y => y.ID > 0).Select(x => x.ID).Distinct().Contains(x.ID));
                    if (listDelete != null && listDelete.Count() > 0)
                    {
                        _appDbContext.HrCandidateLanguages.RemoveRange(listDelete);
                        _appDbContext.SaveChanges();
                    }

                    foreach (var item in entries)
                    {
                        var dbRec = list.Where(x => x.ID == item.ID).FirstOrDefault();
                        if (dbRec == null) //new
                        {
                            item.ID = default;
                        }
                        item.DateLastModified = DateTime.UtcNow;
                        item.UserModified = entries.FirstOrDefault().UserModified;

                        _appDbContext.HrCandidateLanguages.Add(item);
                        _appDbContext.Entry(item).State = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    }
                    _appDbContext.SaveChanges();
                    transaction.Commit();

                    return _appDbContext.HrCandidateLanguages.Where(x => x.CandidateID == entries.First().CandidateID ).AsNoTracking().ToList();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool? DeleteRecord(int id, string userId)
		{
            var entryToDelete = _appDbContext.HrCandidates.FirstOrDefault(e => e.CandidateID == id);
            if (entryToDelete == null) return false;

            _appDbContext.HrCandidates.Remove(entryToDelete);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool? DeleteResumeComponent(string docType, int candidateId, int recId)
        {
            if(docType.Compare("CERT"))
            {
                var entryToDelete = _appDbContext.HrCandidateCertificates.FirstOrDefault(e => e.CandidateID == candidateId && e.ID == recId);
                if (entryToDelete == null) return null;
                _appDbContext.HrCandidateCertificates.Remove(entryToDelete);
                _appDbContext.SaveChanges();
                return true;
            }
            else if (docType.Compare("EDUC"))
            {
                var entryToDelete = _appDbContext.HrCandidateEducations.FirstOrDefault(e => e.CandidateID == candidateId && e.ID == recId);
                if (entryToDelete == null) return null;
                _appDbContext.HrCandidateEducations.Remove(entryToDelete);
                _appDbContext.SaveChanges();
                return true;
            }
            else if (docType.Compare("EXPE"))
            {
                var entryToDelete = _appDbContext.HrCandidateExperiences.FirstOrDefault(e => e.CandidateID == candidateId && e.ID == recId);
                if (entryToDelete == null) return null;
                _appDbContext.HrCandidateExperiences.Remove(entryToDelete);
                _appDbContext.SaveChanges();
                return true;
            }
            else if (docType.Compare("SKIL"))
            {
                var entryToDelete = _appDbContext.HrCandidateSkills.FirstOrDefault(e => e.CandidateID == candidateId && e.ID == recId);
                if (entryToDelete == null) return null;
                _appDbContext.HrCandidateSkills.Remove(entryToDelete);
                _appDbContext.SaveChanges();
                return true;
            }
            else if (docType.Compare("LANG"))
            {
                var entryToDelete = _appDbContext.HrCandidateLanguages.FirstOrDefault(e => e.CandidateID == candidateId && e.ID == recId);
                if (entryToDelete == null) return null;
                _appDbContext.HrCandidateLanguages.Remove(entryToDelete);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCandidateStat(int id, int jobOrderId, string statType, string statValue)
        {
            return UpdateCandidateStat(statType, id, jobOrderId, statValue);
        }

        private bool UpdateCandidateStat(string statType, int candidateId, int jobOrderId, string statValue)
        {
            if(statType.Compare("Bookmark"))
            {
                var dbentry = _appDbContext.HrCandidateJobBookmarks
                    .Where(e => e.CandidateID == candidateId && e.JobOrderID == jobOrderId);
                if (dbentry != null && dbentry.Count() > 0)
                {
                    if (statValue == "Y")
                    {
                        return true;
                    }
                    else
                    {
                        _appDbContext.HrCandidateJobBookmarks.RemoveRange(dbentry);
                        _appDbContext.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    if (statValue == "Y")
                    {
                        var newentry = new HrCandidateJobBookmark() { JobOrderID = jobOrderId, CandidateID = candidateId };
                        _appDbContext.HrCandidateJobBookmarks.Add(newentry);
                        _appDbContext.Entry(newentry).State = EntityState.Added;
                        _appDbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        #region Candidate multi data (eg: multiple-resumes)
        public List<HrCandidateMultiData> GetCandidateMultiData(int candidateId, string recordType)
        {
            var recs = _appDbContext.HrCandidateMultiDatas.Where(c => c.CandidateID == candidateId).ToList();
            recs.ForEach(x => x.DynmcFileUrl = _cdnFileService.GetCandidateResumeUrl(x.CandidateID, x.EntityValue));

            return recs;
        }

        public List<HrCandidateMultiData> UpdateCandidateMultiData(List<HrCandidateMultiData> candidateMultiDatas, string dropAndCreateMode)
        {
            var candId = candidateMultiDatas.FirstOrDefault().CandidateID;
            var recType = candidateMultiDatas.FirstOrDefault().RecordType;

            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    UpdateCandidateMultiData(transaction, candidateMultiDatas, candId, recType, dropAndCreateMode);
                    transaction.Commit();
                    return _appDbContext.HrCandidateMultiDatas.Where(x => x.CandidateID == candId && x.RecordType == recType).AsNoTracking().ToList();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private bool UpdateCandidateMultiData(IDbContextTransaction transaction, List<HrCandidateMultiData> candidateMultiDatas,
            int candidateId, string multiRecordType, string dropAndCreateMode = "")
        {
            if (dropAndCreateMode.Contains("DropAll"))
            {
                var list = _appDbContext.HrCandidateMultiDatas.Where(x => x.CandidateID == candidateId && x.RecordType == multiRecordType).AsNoTracking().ToList();

                var listDelete = list.Where(x => !candidateMultiDatas.Where(y => y.ID > 0).Select(x => x.ID).Distinct().Contains(x.ID));
                if (listDelete != null && listDelete.Count() > 0)
                {
                    _appDbContext.HrCandidateMultiDatas.RemoveRange(listDelete);
                    _appDbContext.SaveChanges();
                }
            }

            candidateMultiDatas.ForEach(x => x.DateUpdated = DateTime.UtcNow);
            _appDbContext.HrCandidateMultiDatas.UpdateRange(candidateMultiDatas);
            _appDbContext.SaveChanges();

            return true;
        }

        public async Task<bool> UploadResumeFile(int candidateId, IFormFileCollection attachments, List<HrCandidateMultiData> candidateMultiDatas)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    var fileNames = attachments.Select(x => x.FileName).Distinct().ToList();
                    var existRecs = _appDbContext.HrCandidateMultiDatas
                        .Where(x => x.CandidateID == candidateId && x.RecordType == HrCandidateMultiDataTypes.CandidateResumeFile)
                        .AsNoTracking().ToList();


                    if((existRecs?.Count??0) >= 2)
                    {
                        throw new ArgumentException("Your subscription only allows for maximum of two resumes only.");
                    }

                    if (existRecs?.Count > 0 && existRecs.Any(x=> fileNames.Contains(x.EntityValue)))
                    {
                        throw new ArgumentException("The file already exists.");
                    }

                    //Update candidate multi Data (resume details)
                    UpdateCandidateMultiData(transaction, candidateMultiDatas, candidateId, HrCandidateMultiDataTypes.CandidateResumeFile);

                    //Upload blobs
                    var isUploadedFailed = false;
                    foreach (var file in attachments)
                    {
                        using (Stream stream = file.OpenReadStream())
                        {
                            var isUploaded = await _blobStorageService.UploadFileToStorage(
                                stream, 
                                _azureBlobStorageConfig.CandidateResumeContainer, 
                                $"{candidateId}/{file.FileName}", 
                                true);
                            if (!isUploaded) isUploadedFailed = true;
                        }
                    }

                    if (isUploadedFailed)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<bool> DeleteResumeFile(int candidateId, string fileName)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    //Remove candidate multi Data (resume details)
                    var listDelete = _appDbContext.HrCandidateMultiDatas
                        .Where(x => x.CandidateID == candidateId
                            && x.RecordType == HrCandidateMultiDataTypes.CandidateResumeFile
                            && x.EntityValue == fileName)
                        .AsNoTracking().ToList();

                    if (listDelete != null && listDelete.Count() > 0)
                    {
                        _appDbContext.HrCandidateMultiDatas.RemoveRange(listDelete);
                        _appDbContext.SaveChanges();
                    }

                    //Delete blobs
                    var isDeletionFailed = false;
                    var isDeleted = await _blobStorageService.DeleteFileFromStorage(
                        _azureBlobStorageConfig.CandidateResumeContainer,
                        $"{candidateId}/{fileName}");
                    if (!isDeleted) isDeletionFailed = true;

                    if (isDeletionFailed)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        #endregion
    }
}
