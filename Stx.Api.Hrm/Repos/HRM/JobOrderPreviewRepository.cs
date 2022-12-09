using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Api.Hrm.Interfaces.Services;
using Stx.Shared;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Repos.HRM
{
    public class JobOrderPreviewRepository : IJobOrderPreviewRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly ICdnFileService _cdnFileService;

        public JobOrderPreviewRepository(StxDbContext appDbContext, 
            ILogger<JobOrderPreviewRepository> logger,
            ICdnFileService cdnFileService
            )
        {
            _appDbContext = appDbContext;
            _cdnFileService = cdnFileService;
        }


        public HrJobOrderPreviewDTO GetRecordByID(int id, int candidateID)
		{
            string qry = $"EXEC [HRMJobOrderPreview] @JobOrderID={id}, @CandidateID={candidateID}";
            var entry = _appDbContext.Set<HrJobOrderPreviewDTO>().FromSqlRaw(qry).AsEnumerable().FirstOrDefault();
            entry.DynmcImageUrl = _cdnFileService.GetCompanyLogoUrl(entry.LogoImgKey);
            return entry;
        }


        /// <summary>
        /// This method is used to save the candidate's actions for a Job order
        /// Actions:  
        ///     ActionName      ActionValue
        ///     ----------      ------------
        ///     alert           Y | N
        ///     bookmark	    1, 2, 3 … (save lists)
        ///     report          spam | abuse | Inappropriate | violent | other {custom value}
        ///     view-appl-stat  Y | N
        ///     
        /// </summary>
        /// <param name="actionName"> Name or type of the action</param>
        /// <param name="actionValue">Value of the action </param>
        /// <param name="userId">User id </param>
        /// <returns></returns>
        public string Action(CandidateJobOrderActionDto actionDto)
        {
            if (!string.IsNullOrWhiteSpace(actionDto.ActionName) && actionDto.JobOrderID > 0 && actionDto.CandidateID > 0)
            {
                //TODO Save all other candidate-job actions
                if(actionDto.ActionName.ToLower()== "bookmark")
                {
                    if (actionDto.ActionValue.ToLower() == "y")
                    {
                        HrCandidateJobBookmark entry = new HrCandidateJobBookmark();
                        entry.CandidateID = actionDto.CandidateID;
                        entry.JobOrderID = actionDto.JobOrderID;
                        _appDbContext.Update(entry);
                        _appDbContext.SaveChanges();
                        return "succuss";
                    }
                    else if (actionDto.ActionValue.ToLower() == "n")
                    {
                        var entriesToDel = _appDbContext.HrCandidateJobBookmarks.Where(x => x.CandidateID == actionDto.CandidateID && x.JobOrderID == actionDto.JobOrderID);
                        _appDbContext.HrCandidateJobBookmarks.RemoveRange(entriesToDel);
                        _appDbContext.SaveChanges();
                        return "succuss";
                    }
                }
                else if(actionDto.ActionName.ToLower()== "alert")
                {
                    if (actionDto.ActionValue.ToLower() == "y")
                    {
                        var entryToUpdate = _appDbContext.HrCandidateJobActivities
                            .Where(x => x.CandidateID == actionDto.CandidateID && x.JobOrderID == actionDto.JobOrderID
                            && x.ActivityType == "alert").FirstOrDefault();
                        if(entryToUpdate == null)
                            entryToUpdate = new HrCandidateJobActivity();

                        entryToUpdate.CandidateID = actionDto.CandidateID;
                        entryToUpdate.JobOrderID = actionDto.JobOrderID;
                        entryToUpdate.ActivityType = "alert";
                        entryToUpdate.Value = actionDto.ActionValue;

                        _appDbContext.Update(entryToUpdate);
                        _appDbContext.SaveChanges();
                        return "succuss";
                    }
                    else if (actionDto.ActionValue.ToLower() == "n")
                    {
                        var entriesToDel = _appDbContext.HrCandidateJobActivities
                            .Where(x => x.CandidateID == actionDto.CandidateID && x.JobOrderID == actionDto.JobOrderID 
                            && x.ActivityType == "alert");
                        _appDbContext.HrCandidateJobActivities.RemoveRange(entriesToDel);
                        _appDbContext.SaveChanges();
                        return "succuss";
                    }
                }
                else if (actionDto.ActionName.ToLower() == "report")
                {
                    var entryToUpdate = _appDbContext.HrCandidateJobActivities
                        .Where(x => x.CandidateID == actionDto.CandidateID && x.JobOrderID == actionDto.JobOrderID
                        && x.ActivityType == "report" && x.Value == actionDto.ActionValue).FirstOrDefault();
                    if (entryToUpdate == null)
                        entryToUpdate = new HrCandidateJobActivity();

                    entryToUpdate.CandidateID = actionDto.CandidateID;
                    entryToUpdate.JobOrderID = actionDto.JobOrderID;
                    entryToUpdate.ActivityType = "report";
                    entryToUpdate.Value = actionDto.ActionValue;
                    entryToUpdate.DateUpdated = DateTime.UtcNow;

                    _appDbContext.Update(entryToUpdate);
                    _appDbContext.SaveChanges();
                    return "succuss";                    
                }
                return "notfound";
            }
            else
            {
                return null;
            }
        }

    }
}
