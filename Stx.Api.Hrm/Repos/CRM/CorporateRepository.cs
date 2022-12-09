using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stx.Api.Hrm.Configurations;
using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Api.Hrm.Interfaces.Services;
using Stx.Shared.Api.Interfaces;
using Stx.Shared.Models.CRM;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Repos.CRM
{
    public class CorporateRepository : ICorporateRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly IBlobStorageService _blobStorageService;
        private readonly ICdnFileService _cdnFileService;
        private readonly AzureStorageConfiguration _azureBlobStorageConfig = null;

        public CorporateRepository(StxDbContext appDbContext, 
            IBlobStorageService blobStorageService,
            ICdnFileService cdnFileService,
            IOptionsMonitor<AzureStorageConfiguration> config
            )
        {
            _appDbContext = appDbContext;
            _blobStorageService = blobStorageService;
            _cdnFileService = cdnFileService;
            _azureBlobStorageConfig = config.CurrentValue;
        }

        public List<Corporate> GetAllRecords()
        {
            var corp = _appDbContext.Corporates.OrderByDescending(x => x.CorporateID).Take(150).ToList();
            corp.ForEach(x => x.DynmcImageUrl = _cdnFileService.GetCompanyLogoUrl(x.LogoImgKey));
            return corp;
        }

        public Corporate GetRecordByID(int id)
		{
            var corp = _appDbContext.Corporates.Where(c => c.CorporateID == id).FirstOrDefault();
            corp.DynmcImageUrl = _cdnFileService.GetCompanyLogoUrl(corp.LogoImgKey);
            return corp;
        }

        public Corporate UpdateRecord(Corporate entry, EntryState entryState, string userId)
		{
            if (entryState == EntryState.New)
            {
                entry.DateAdded = DateTime.UtcNow;
                entry.DateLastModified = DateTime.UtcNow;
                var addedEntity = _appDbContext.Corporates.Add(entry);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            else
			{
                entry.DateLastModified = DateTime.UtcNow;
                _appDbContext.Corporates.Add(entry);
                _appDbContext.Entry(entry).State = EntityState.Modified;

                _appDbContext.SaveChanges();

                var entryToUpdate = _appDbContext.Corporates.FirstOrDefault(e => e.CorporateID == entry.CorporateID);

                if (entryToUpdate != null)
                {
                    return entryToUpdate;
                }

                return null;
            }
        }

        public async Task<bool> UpdateProfileLogo(IFormFile formFile, string fileName, int corporateId)
        {
            bool isUploaded = false;

            if (formFile.Length > 0)
            {
                using (Stream stream = formFile.OpenReadStream())
                {
                    isUploaded = await _blobStorageService.UploadFileToStorage(stream, _azureBlobStorageConfig.CandidateProfileImgContainer, fileName, true);
                }
            }

            if (isUploaded)
            {
                var entryToUpdate = _appDbContext.Corporates.FirstOrDefault(e => e.CorporateID == corporateId);
                entryToUpdate.LogoImgKey = fileName;
                _appDbContext.Corporates.Add(entryToUpdate);
                _appDbContext.Entry(entryToUpdate).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                return isUploaded;
            }
            return false;
        }


        public bool? DeleteRecord(int id, string userId)
		{
            //NOT ALLOWED

            //var entryToDelete = _appDbContext.Corporates.FirstOrDefault(e => e.CorporateID == id);
            //if (entryToDelete == null) return false;

            //_appDbContext.Corporates.Remove(entryToDelete);
            //_appDbContext.SaveChanges();
            //return true;
            return false;
        }
	}
}
