using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Repos.HRM
{
    public class CandidateSignupRepository : ICandidateSignupRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CandidateSignupRepository(StxDbContext appDbContext, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) 
        {
            _appDbContext = appDbContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<bool> Signup(UserSignupDTO entry)
        {
        //    return CreateUser(entry);
        //}
        //private async Task<bool> CreateUser(UserSignupDTO entry)
        //{
                using var transaction = _appDbContext.Database.BeginTransaction();
                {
                    try
                    {
                        var nextCandId = _appDbContext.HrCandidates.Max(x => x.CandidateID) + 1;
                        HrCandidate newCandidate = new HrCandidate();
                        newCandidate.CandidateID = nextCandId;
                        newCandidate.FirstName = entry.FirstName;
                        newCandidate.LastName = entry.LastName;
                        newCandidate.UserName = entry.Email;
                        newCandidate.DateLastModified = DateTime.UtcNow;

                        var addedEntity = _appDbContext.HrCandidates.Add(newCandidate);

                        var user = new ApplicationUser
                        {
                            UserName = entry.Email,
                            Email = entry.Email,
                            FirstName = entry.FirstName,
                            LastName = entry.LastName
                        };

                        // Store user data in AspNetUsers database table
                        var result = await _userManager.CreateAsync(user, entry.Password);

                        if (result.Succeeded)
                        {
                            _appDbContext.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return false;
            //});
        }
        

	}
}
