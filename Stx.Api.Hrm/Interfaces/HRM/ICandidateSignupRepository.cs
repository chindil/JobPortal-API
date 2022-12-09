using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Interfaces.HRM
 {
    public interface ICandidateSignupRepository
    {
        //public bool Signup(UserSignupDTO entry);
        public Task<bool> Signup(UserSignupDTO entry);

        //public bool? DeleteRecord(int id, string userId);
    }
}
