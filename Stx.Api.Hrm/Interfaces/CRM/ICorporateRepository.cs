using Microsoft.AspNetCore.Http;
using Stx.Shared.Models.CRM;
using Stx.Shared.Status;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Interfaces.CRM
{
    public interface ICorporateRepository
    {
        public List<Corporate> GetAllRecords();

        public Corporate GetRecordByID(int id);

        public Corporate UpdateRecord(Corporate entry, EntryState entryState, string userId);
        public Task<bool> UpdateProfileLogo(IFormFile formFile, string imageFilename, int corporateId);

        public bool? DeleteRecord(int id, string userId);
    }
}
