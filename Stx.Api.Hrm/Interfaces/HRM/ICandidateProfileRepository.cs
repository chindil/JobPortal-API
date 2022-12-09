using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Stx.Shared;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Interfaces.HRM
 {
    public interface ICandidateProfileRepository
    {
        public HrCandidateProfile GetRecordByID(int id);
        public HrCandidateProfile UpdateRecord(HrCandidateProfile entry, EntryState entryState, string userId);
        public Task<bool> UpdateProfileImage(IFormFile formFile, int candidateId);
    }
}
