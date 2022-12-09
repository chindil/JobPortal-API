using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Interfaces.Account;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared;
using Stx.Shared.Models.Account;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Repos.HRM 
{
    public class AccountRepository : IAccountRepository 
    {
        private readonly StxDbContext _appDbContext;
        private ILogger<AccountRepository> _logger;

        public readonly UserManager<ApplicationUser> userManager;
        public readonly SignInManager<ApplicationUser> signInManager;

        public AccountRepository(StxDbContext appDbContext, ILogger<AccountRepository> logger, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _appDbContext = appDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
        }

        public async Task<SigninUser> RegisterUser(SigninUser record)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = record.Email,
                    Email = record.Email,
                    FirstName = record.FirstName,
                    LastName = record.LastName
                };
                var result = await userManager.CreateAsync(user, record.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: true);
                    return record;
                }
                else
                {
                    if (result.Errors.Any())
                        _logger.LogError(result.Errors.First().Description, result.Errors);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

	}
}
