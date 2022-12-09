using Stx.Api.Hrm.Repos;
using Stx.Shared.Models.Account;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Interfaces.Account
{
    public interface IAccountRepository
    {
        public Task<SigninUser> RegisterUser(SigninUser record);
    }
}
