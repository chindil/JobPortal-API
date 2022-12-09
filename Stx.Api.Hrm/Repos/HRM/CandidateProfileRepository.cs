using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stx.Api.Hrm.Configurations;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Api.Hrm.Interfaces.Services;
using Stx.Api.Hrm.Services;
using Stx.Shared;
using Stx.Shared.Api.Interfaces;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Repos.HRM 
{
    public class CandidateProfileRepository : ICandidateProfileRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly IBlobStorageService _blobStorageService;
        private readonly ICdnFileService _cdnFileService;
        private readonly AzureStorageConfiguration _azureBlobStorageConfig = null;

        public CandidateProfileRepository(StxDbContext appDbContext, 
            ILogger<CandidateSignupRepository> logger, 
            IBlobStorageService blobStorageService,
            ICdnFileService cdnFileService,
            IOptionsMonitor<AzureStorageConfiguration> config)
        {
            _appDbContext = appDbContext;
            _blobStorageService = blobStorageService;
            _cdnFileService = cdnFileService;
            _azureBlobStorageConfig = config.CurrentValue;
        }

        public HrCandidateProfile GetRecordByID(int id)
        {
            var cand = (from c in _appDbContext.HrCandidates
                        join cnt in _appDbContext.Countries on c.CountryID equals cnt.CountryID into country
                        from ct in country.DefaultIfEmpty()
                        where c.CandidateID == id
                        select new { c, ct.Name }).FirstOrDefault();
            if(cand == null)
            {
                return null;
            }

            var candprofile =  new HrCandidateProfile
            {
                CandidateID = cand.c.CandidateID,
                UserName = cand.c.UserName,
                Password = "",
                FirstName = cand.c.FirstName,
                MiddleName = cand.c.MiddleName,
                LastName = cand.c.LastName,
                NickName = cand.c.NickName,
                Gender = cand.c.Gender,
                NamePrefix = cand.c.NamePrefix,
                NameSuffix = cand.c.NameSuffix,
                Nationality = cand.c.Nationality,
                Mobile = cand.c.Mobile,
                Phone = cand.c.Phone,
                Phone2 = cand.c.Phone2,
                WorkPhone = cand.c.WorkPhone,
                Email = cand.c.Email,
                Email2 = cand.c.Email2,
                Fax = cand.c.Fax,
                Fax2 = cand.c.Fax2,
                Address = cand.c.Address,
                PostalCode = cand.c.PostalCode,
                SecondaryAddress = cand.c.SecondaryAddress,
                MaritalStatus = cand.c.MaritalStatus,
                DateOfBirth = cand.c.DateOfBirth,
                DateAvailable = cand.c.DateAvailable,
                DateLastComment = cand.c.DateLastComment,
                DateLastModified = cand.c.DateLastModified,
                DateNextCall = cand.c.DateNextCall,
                TimeZoneOffsetEST = cand.c.TimeZoneOffsetEST,
                Disability = cand.c.Disability,
                Active = cand.c.Active,
                CountryName = cand.Name,
                City = cand.c.City,
                CurrentJobTitle = cand.c.CurrOccupation,
            };
            candprofile.DynmcImageUrl = _cdnFileService.GetCandidateProfileImageUrl(cand.c.ProfileImgKey);
            return candprofile;
        }

        public async Task<bool> UpdateProfileImage(IFormFile formFile, int candidateId)
        {
            bool isUploaded = false;

            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    var newImgFilename = FileService.GetNewFilenameWithPrefix(candidateId.ToString(), formFile.FileName, 15, DateTime.Now.ToString("HHmmssfff"), "_");

                    if (formFile.Length > 0)
                    {
                        var oldFileNameToDelete = _appDbContext.HrCandidates.Where(e => e.CandidateID == candidateId).Select(x=> x.ProfileImgKey).FirstOrDefault();

                        var entryToUpdate = _appDbContext.HrCandidates.FirstOrDefault(e => e.CandidateID == candidateId);
                        entryToUpdate.ProfileImgKey = newImgFilename;
                        _appDbContext.HrCandidates.Add(entryToUpdate);
                        _appDbContext.Entry(entryToUpdate).State = EntityState.Modified;
                        _appDbContext.SaveChanges();


                        using (Stream stream = formFile.OpenReadStream())
                        {
                            isUploaded = await _blobStorageService.UploadFileToStorage(stream, _azureBlobStorageConfig.CandidateProfileImgContainer, newImgFilename, true, oldFileNameToDelete);
                        }
                    }

                    if (isUploaded)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            
            return false;
        }

        public HrCandidateProfile UpdateRecord(HrCandidateProfile entry, EntryState entryState, string userId)
		{
            if (entryState == EntryState.Update)
            {
                var entryToUpdate = _appDbContext.HrCandidates.FirstOrDefault(e => e.CandidateID == entry.CandidateID);
                if (entryToUpdate == null)
                {
                    return null;
                }
                entryToUpdate.UserName = entry.UserName;
                entryToUpdate.FirstName = entry.FirstName;
                entryToUpdate.MiddleName = entry.MiddleName;
                entryToUpdate.LastName = entry.LastName;
                entryToUpdate.NickName = entry.NickName;
                entryToUpdate.Gender = entry.Gender;
                entryToUpdate.NamePrefix = entry.NamePrefix;
                entryToUpdate.NameSuffix = entry.NameSuffix;
                entryToUpdate.Nationality = entry.Nationality;
                entryToUpdate.Mobile = entry.Mobile;
                entryToUpdate.Phone = entry.Phone;
                entryToUpdate.Phone2 = entry.Phone2;
                entryToUpdate.WorkPhone = entry.WorkPhone;
                entryToUpdate.Email = entry.Email;
                entryToUpdate.Email2 = entry.Email2;
                entryToUpdate.Fax = entry.Fax;
                entryToUpdate.Fax2 = entry.Fax2;
                entryToUpdate.Address = entry.Address;
                entryToUpdate.PostalCode = entry.PostalCode;
                entryToUpdate.SecondaryAddress = entry.SecondaryAddress;
                entryToUpdate.MaritalStatus = entry.MaritalStatus;
                entryToUpdate.DateOfBirth = entry.DateOfBirth;
                entryToUpdate.DateAvailable = entry.DateAvailable;
                entryToUpdate.DateLastComment = entry.DateLastComment;
                entryToUpdate.DateLastModified = entry.DateLastModified;
                entryToUpdate.DateNextCall = entry.DateNextCall;
                entryToUpdate.TimeZoneOffsetEST = entry.TimeZoneOffsetEST;
                entryToUpdate.Disability = entry.Disability;
                entryToUpdate.Active = entry.Active;

                _appDbContext.HrCandidates.Add(entryToUpdate);
                _appDbContext.Entry(entryToUpdate).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                return entry;

            }
            return null;
        }

	}
}
