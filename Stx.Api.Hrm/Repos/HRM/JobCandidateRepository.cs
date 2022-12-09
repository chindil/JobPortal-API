using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Api.Hrm.Interfaces.Services;
using Stx.Shared;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Repos.HRM
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly ICdnFileService _cdnFileService;

        public JobCandidateRepository(StxDbContext appDbContext, 
            ICdnFileService cdnFileService,
            ILogger<JobCandidateRepository> logger)
        {
            _appDbContext = appDbContext;
            _cdnFileService = cdnFileService;
        }


        public HrJobCandidate GetRecordByID(int jobCandidateId)
        {
            var jobcand = (from jc in _appDbContext.HrJobCandidates
                         join c in _appDbContext.HrCandidates on jc.CandidateID equals c.CandidateID into cand
                         from cf in cand.DefaultIfEmpty()
                         select new { jc, CandProfileImgKey = cf.ProfileImgKey }).FirstOrDefault();

            jobcand.jc.DynmcImageUrl = _cdnFileService.GetCandidateProfileImageUrl(jobcand.CandProfileImgKey);
            return jobcand.jc;
        }

        public List<HrJobCandidateListDTO> GetRecordListByStage(string candidateStage, int jobOrderId)
        {
            string qry = "EXEC [HRMJobCandidateListByStage] @Stage, @JobOrderID";

            object[] parm =
            {
                new SqlParameter("@Stage", candidateStage),
                new SqlParameter("@JobOrderID", jobOrderId),
            };

            var results = _appDbContext.Set<HrJobCandidateListDTO>().FromSqlRaw(qry, parm).AsEnumerable().ToList();
            results.ForEach(x => x.DynmcImageUrl = _cdnFileService.GetCandidateProfileImageUrl(x.ProfileImgKey));
            return results;
        }

        /// <summary>
        /// Insert/Import a corporate job candidate
        /// </summary>
        /// <param name="entry">Candidate info</param>
        /// <param name="entryState">Entry type (Add/Update)</param>
        /// <param name="userId">Current user id</param>
        /// <returns></returns>
        public HrJobCandidate UpdateRecord(HrJobCandidate entry, EntryState entryState, string userId)
        {
            var addedEntity = _appDbContext.HrJobCandidates.Add(entry);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
  
        }

        public bool? DeleteRecord(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public List<HrJobCandidateListDTO> Search(HrJobCandidateParmDTO searchParms)
        {
            var jcand = (from jc in _appDbContext.HrJobCandidates 
                         join jo in _appDbContext.HrJobOrders on jc.JobOrderID equals jo.JobOrderID 
                         join c in _appDbContext.HrCandidates on jc.CandidateID equals c.CandidateID
                         where jc.CorporateID == searchParms.CorporateID
                         select new { jc, jo.Title, c.ProfileImgKey});
            if(searchParms.JobOrderIds?.Count > 0)
            {
                jcand.Where(x => searchParms.JobOrderIds.Contains(x.jc.JobOrderID));
            }
            if (searchParms.Stages?.Count > 0)
            {
                jcand.Where(x => searchParms.Stages.Contains(x.jc.Stage));
            }
            if (!string.IsNullOrWhiteSpace(searchParms.CandidateSource))
            {
                jcand.Where(x => searchParms.CandidateSource == x.jc.CandidateSource);
            }
            if (searchParms.IsActive.HasValue)
            {
                jcand.Where(x => searchParms.IsActive == x.jc.Active);
            }

            List<HrJobCandidateListDTO> ret = new List<HrJobCandidateListDTO>();
            jcand.ToList().ForEach(x=>
            {
                ret.Add(new HrJobCandidateListDTO()
                {
                    Selected = false,
                    CandidateID = x.jc.CandidateID, 
                    CandidateName = string.Concat(x.jc.FirstName , " " , x.jc.LastName),
                    Email = x.jc.Email,
                    Mobile = x.jc.Mobile, 
                    JobCandidateID = x.jc.JobCandidateID, 
                    JobOrderID = x.jc.JobOrderID,
                    DateAdded = x.jc.DateAdded, 
                    Stage = x.jc.Stage,
                    JobTitle = x.Title,
                    ProfileImgKey = x.jc.ProfileImgKey,
                    DynmcImageUrl = _cdnFileService.GetCandidateProfileImageUrl(x.ProfileImgKey)
                });
            });

            return ret;
            
        }

    }
}
