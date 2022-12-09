using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Infrastructure.Image;
using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Api.Hrm.Interfaces.Services;
using Stx.Shared.Models.CRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Repos.CRM
{
    public class CorporateSettingsRepository : ICorporateSettingsRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly ICdnFileService _cdnFileService;
        public static IImageHandler _imageHandler;

        public CorporateSettingsRepository(StxDbContext appDbContext,
            ICdnFileService cdnFileService,
            ILogger<ICorporateSettingsRepository> logger, IImageHandler imageHandler)
        {
            _appDbContext = appDbContext;
            _cdnFileService = cdnFileService;
            _imageHandler = imageHandler;
        }

        public string UpdateProfileImage(IFormFile file, string userId)
        {
            string fName = file.FileName;
            //string path = Path.Combine(_hostingEnvironment.WebRootPath, "Hrm/Images/100/" + file.FileName); 
            string path = _imageHandler.GetPhysicalFilePathFromData(100, userId, file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return file.FileName;
        }

        public Corporate GetProfile(int id)
        {
            var entry = _appDbContext.Corporates.Where(c => c.CorporateID == id).FirstOrDefault();
            var corp = new Corporate()
            {
                CorporateID = entry.CorporateID,
                Name = entry.Name,
                Phone = entry.Phone,
                ShortName = entry.ShortName,
                UserName = entry.UserName,
                Website = entry.Website,
                Address = entry.Address,
                Address2 = entry.Address2,
                City = entry.City,
                CountryID = entry.CountryID,
                Email = entry.Email,
                Mobile = entry.Mobile,
                Remarks = entry.Remarks,
                LogoImgKey = entry.LogoImgKey,
                LogoThumbImgKey = entry.LogoThumbImgKey
            };
            corp.DynmcImageUrl = _cdnFileService.GetCompanyLogoUrl(corp.LogoImgKey);
            return corp;
        }

        public Corporate UpdateProfile(Corporate entry, string userId)
        {
            var entryToUpdate = _appDbContext.Corporates.Where(c => c.CorporateID == entry.CorporateID).FirstOrDefault();

            entryToUpdate.DateLastModified = DateTime.UtcNow;
            entryToUpdate.CorporateID = entry.CorporateID;
            entryToUpdate.Name = entry.Name;
            entryToUpdate.Phone = entry.Phone;
            entryToUpdate.ShortName = entry.ShortName;
            entryToUpdate.UserName = entry.UserName;
            entryToUpdate.Website = entry.Website;
            entryToUpdate.Address = entry.Address;
            entryToUpdate.Address2 = entry.Address2;
            entryToUpdate.City = entry.City;
            entryToUpdate.CountryID = entry.CountryID;
            entryToUpdate.Email = entry.Email;
            entryToUpdate.Mobile = entry.Mobile;
            entryToUpdate.Remarks = entry.Remarks;
            entryToUpdate.DateLastModified = DateTime.UtcNow;
            entryToUpdate.UserModified = userId;

            _appDbContext.Corporates.Add(entryToUpdate);
            _appDbContext.Entry(entryToUpdate).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return _appDbContext.Corporates.FirstOrDefault(e => e.CorporateID == entry.CorporateID);
        }

        public List<HrAtsDepartment> GetDepartments(int id)
        {
            return _appDbContext.HrAtsDepartments.Where(c => c.CorporateID == id).OrderBy(x=> x.Name).ToList();           
        }

        public HrAtsDepartment UpdateDepartments(HrAtsDepartment entry, string userId)
        {
            var dbRec = _appDbContext.HrAtsDepartments.Where(x => x.ID == entry.ID).FirstOrDefault();
            if (dbRec == null)
            {
                dbRec = new HrAtsDepartment();
                dbRec.ID = -1;
                dbRec.DateAdded = DateTime.UtcNow;
                dbRec.UserAdded = userId;
            }
            dbRec.ID = entry.ID;
            dbRec.CorporateID = entry.CorporateID;
            dbRec.DepartmentID = entry.DepartmentID;
            dbRec.Name = entry.Name;
            dbRec.Desc = entry.Desc;
            dbRec.Active = entry.Active;
            dbRec.DateLastModified = DateTime.UtcNow;
            dbRec.UserModified = userId;

            _appDbContext.HrAtsDepartments.Add(dbRec);
            _appDbContext.Entry(dbRec).State = dbRec.ID > 0 ? EntityState.Modified : EntityState.Added;
            _appDbContext.SaveChanges();
            dbRec = _appDbContext.HrAtsDepartments.Where(x => x.ID == entry.ID).FirstOrDefault();
            entry.ID = dbRec.ID;
            return entry;
        }

        public List<HrAtsTeamDTO> GetTeams(int id)
        {
            var entries = new List<HrAtsTeamDTO>();
            var data = (from t in _appDbContext.HrAtsTeams
                        join users in _appDbContext.Users 
                            on t.Email equals users.Email into jointable
                        from u in jointable.DefaultIfEmpty()
                        where t.CorporateID == id
             select new { t, u.FirstName, u.LastName });

            data.OrderBy(x => x.FirstName).ToList().ForEach(x =>
            {
                entries.Add(new HrAtsTeamDTO
                {
                    ID = x.t.ID,
                    CorporateID = x.t.CorporateID,
                    CorpUserID = x.t.CorpUserID,
                    Email = x.t.Email,
                    Name = string.Concat(x.FirstName, " ", x.LastName),
                    Tags = x.t.Tags,
                    DateLastModified = x.t.DateLastModified,
                    IsReqAccepted = x.t.IsReqAccepted,
                    Active = x.t.Active,
                });
            });
            return entries;
        }

        public HrAtsTeamDTO UpdateTeams(HrAtsTeamDTO entry, List<HrAtsTeamJob> assignJobs, string userId)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                var dbRec = _appDbContext.HrAtsTeams.Where(x => x.ID == entry.ID).FirstOrDefault();
                if (dbRec == null)
                {
                    dbRec = new HrAtsTeam();
                    dbRec.ID = 0;
                    dbRec.DateAdded = DateTime.UtcNow;
                    dbRec.CorpUserID = entry.CorpUserID;
                }
                dbRec.CorporateID = entry.CorporateID;
                dbRec.Email = entry.Email;
                //rec.Name = string.Concat(x.FirstName, " ", x.LastName);
                dbRec.Tags = entry.Tags;
                dbRec.UserLevel = entry.UserLevel;
                dbRec.DateLastModified = DateTime.UtcNow;
                dbRec.IsReqAccepted = entry.IsReqAccepted;
                dbRec.Active = entry.Active;
                dbRec.UserModified = userId;
                dbRec.DateLastModified = DateTime.UtcNow;

                _appDbContext.HrAtsTeams.Add(dbRec);
                _appDbContext.Entry(dbRec).State = dbRec.ID > 0 ? EntityState.Modified : EntityState.Added;
                _appDbContext.SaveChanges();
                entry.ID = dbRec.ID;

                //Add-update Ats Team Jobs
                _appDbContext.HrAtsTeamJobs.RemoveRange(_appDbContext.HrAtsTeamJobs.Where(x => x.CorporateID == entry.CorporateID && x.CorpUserID == entry.CorpUserID));
                _appDbContext.SaveChanges();

                if (assignJobs.Count > 0)
                {
                    _appDbContext.HrAtsTeamJobs.AddRange(assignJobs);
                    _appDbContext.Entry(assignJobs).State = EntityState.Added;
                    _appDbContext.SaveChanges();
                }
                transaction.Commit();
                return entry;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public List<HrAtsMailTemplate> GetEmailTemplates(int id)
        {
            return _appDbContext.HrAtsMailTemplates.Where(c => c.CorporateID == id).OrderBy(x => x.Name).ToList();
        }

        public HrAtsMailTemplate UpdateEmailTemplates(HrAtsMailTemplate entry, string userId)
        {
            var dbRec = _appDbContext.HrAtsMailTemplates.Where(x => x.ID== entry.ID).FirstOrDefault();
            if (dbRec == null)
            {
                dbRec = new HrAtsMailTemplate();
                dbRec.ID = default;
                dbRec.DateAdded = DateTime.UtcNow;
                dbRec.UserAdded = userId;
            }
            dbRec.CorporateID = entry.CorporateID;
            dbRec.JobOrderID = entry.JobOrderID;
            dbRec.Name = entry.Name;
            dbRec.Message = entry.Message;
            dbRec.Active = entry.Active;
            dbRec.DateLastModified = DateTime.UtcNow;
            dbRec.UserModified = userId;

            _appDbContext.HrAtsMailTemplates.Add(dbRec);
            _appDbContext.Entry(dbRec).State = dbRec.ID > 0 ? EntityState.Modified : EntityState.Added;
            _appDbContext.SaveChanges();
            entry.ID = dbRec.ID;
            return entry;
        }

        /// <summary>
        /// Get Corporate Benchmarks for Job Portal (GetInterviewTools)
        /// Module 101 is used for ATS.
        /// </summary>
        /// <param name="id">Corporate ID</param>
        /// <returns></returns>
        public List<CorporateBenchmark> GetInterviewTools(int id)
        {
            return _appDbContext.CorporateBenchmarks.Where(c => c.ModuelID == 101 && c.CorporateID == id).OrderBy(x => x.SeqNum).OrderBy(x=> x.BmkCategory).ToList();
        }

        public List<CorporateBenchmark> UpdateInterviewTools(List<CorporateBenchmark> entries, string userId)
        {
            //var dbRec = _appDbContext.CorporateBenchmarks.Where(x => list.Contains(x.ID));
            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    var list = _appDbContext.CorporateBenchmarks
                        .Where(x => x.ModuelID==101 && x.CorporateID == entries.First().CorporateID && x.BmkCategory == entries.First().BmkCategory).AsNoTracking().ToList();

                    var listDelete = list.Where(x => !entries.Where(y => y.ID > 0).Select(x => x.ID).Distinct().Contains(x.ID));
                    if (listDelete != null && listDelete.Count() > 0)
                    {
                        _appDbContext.CorporateBenchmarks.RemoveRange(listDelete);
                        _appDbContext.SaveChanges();
                    }

                    foreach (var item in entries)
                    {
                        var dbRec = list.Where(x => x.ID == item.ID).FirstOrDefault();
                        if (dbRec != null) //existing
                        {
                            item.DateAdded = dbRec.DateAdded;
                            item.UserAdded = dbRec.UserAdded;
                        }
                        else //new-rec
                        {
                            item.ID = default;
                            item.DateAdded = DateTime.UtcNow;
                            item.UserAdded = userId;
                        }
                        item.DateLastModified = DateTime.UtcNow;
                        item.UserModified = userId;
                        item.ModuelID = 101;

                        _appDbContext.CorporateBenchmarks.Add(item);
                        _appDbContext.Entry(item).State = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    }
                    _appDbContext.SaveChanges();
                    transaction.Commit();

                    list = _appDbContext.CorporateBenchmarks
                        .Where(x => x.ModuelID == 101 && x.CorporateID == entries.First().CorporateID && x.BmkCategory == entries.First().BmkCategory).ToList();
                    return list;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        /// <summary>
        /// Get Corporate Settings & Preferences for Job Portal ()
        /// Module 101 is used for ATS.
        /// </summary>
        /// <param name="id">Corporate ID</param>
        /// <returns></returns>
        public List<CorporatePreference> GetCorporatePreference(int id)
        {
            return _appDbContext.CorporatePreferences.Where(c => c.CorporateID == id && c.ModuelID == 101).OrderBy(x => x.SeqNum).OrderBy(x => x.PrefKey).ToList();
        }

        public List<CorporatePreference> UpdateCorporatePreference(List<CorporatePreference> entries, string userId)
        {
            //var list = entries.Where(x => x.ID > 0).Select(x => x.ID).ToList();
            //var dbRec = _appDbContext.CorporateBenchmarks.Where(x => list.Contains(x.ID));
            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    foreach (var item in entries)
                    {
                        if (item.ID <= 0)
                        {
                            item.DateAdded = DateTime.UtcNow;
                            item.UserAdded = userId;
                            item.ModuelID = 101;
                        }
                        item.DateLastModified = DateTime.UtcNow;
                        item.UserModified = userId;

                        _appDbContext.CorporatePreferences.Add(item);
                        _appDbContext.Entry(item).State = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    }
                    _appDbContext.SaveChanges();
                    transaction.Commit();

                    var dbRec = _appDbContext.CorporatePreferences.Where(x => x.CorporateID == entries.First().CorporateID).ToList();
                    return dbRec;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<HrAtsWorkflow> GetWorkflows(int id)
        {
            return _appDbContext.HrAtsWorkflows.Where(c => c.CorporateID == id).OrderBy(x => x.SeqNum).OrderBy(x => x.SeqNum).ToList();
        }

        public List<HrAtsWorkflow> UpdateWorkflows(List<HrAtsWorkflow> entries, string userId)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    foreach (var item in entries)
                    {
                        if (item.ID <= 0)
                        {
                            item.DateAdded = DateTime.UtcNow;
                            item.UserAdded = userId;
                        }
                        item.DateLastModified = DateTime.UtcNow;
                        item.UserModified = userId;

                        _appDbContext.HrAtsWorkflows.Add(item);
                        _appDbContext.Entry(item).State = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    }
                    _appDbContext.SaveChanges();
                    transaction.Commit();

                    return GetWorkflows(entries.First().CorporateID);
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
