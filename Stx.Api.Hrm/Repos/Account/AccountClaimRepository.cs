using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class AccountClaimRepository : IAccountClaimRepository
    {
        private readonly StxDbContext _appDbContext;
        private ILogger<AccountClaimRepository> _logger;

        public readonly UserManager<ApplicationUser> userManager;
        public readonly SignInManager<ApplicationUser> signInManager;

        public AccountClaimRepository(StxDbContext appDbContext, ILogger<AccountClaimRepository> logger, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _appDbContext = appDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
        }

        public async Task<bool?> UpdateRecord(List<SigninUserClaim> entries)
        {
            try
            {
                if (entries.Count == 0) return false;

                foreach (var username in entries.Select(x=> x.UserName).Distinct())
                {
                    var user = await userManager.FindByNameAsync(entries.First().UserName);

                    if (user == null)
                    {
                        _logger.LogError ($"User {username} is not available.");
                        return null;
                    }

                    List<Claim> newclaims = new List<Claim>();
                    entries.Where(x => x.UserName == username).ToList().ForEach(x => newclaims.Add(new Claim(x.ClaimType, x.ClaimValue)));
                    // Get all the user existing claims and delete them
                    //var claims = await userManager.GetClaimsAsync(user);
                    var result = await userManager.RemoveClaimsAsync(user, newclaims);

                    if (!result.Succeeded)
                    {
                        _logger.LogError("Deleting of existing claims failed.");
                        return null;
                    }

                    // Add all the claims that are selected on the UI
                    result = await userManager.AddClaimsAsync(user, newclaims);

                    if (!result.Succeeded)
                    {
                        _logger.LogError("Adding new claims failed.");
                        return null;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

    }
}
