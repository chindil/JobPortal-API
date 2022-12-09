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
    public class CandidatePublicRepository : ICandidatePublicRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly ICdnFileService _cdnFileService;

        public CandidatePublicRepository(StxDbContext appDbContext, 
            ICdnFileService cdnFileService,
            ILogger<CandidatePublicRepository> logger)
        {
            _appDbContext = appDbContext;
            _cdnFileService = cdnFileService;
        }

        public HrCandidatePublicDTO GetRecordByID(int candidateId)
        {
            return GetRecordByID("A", candidateId, null);
        }

        public HrCandidatePublicDTO GetRecordByID(string candidateSource, int candidateId)
        {
            return GetRecordByID(candidateSource, candidateId, null);
        }
        public HrCandidatePublicDTO GetRecordByID(string candidateSource, int candidateId, int? jobOrderId)
        {
            string qry = "EXEC[HRMCandidatePublicInfo] @CandidateSource, @CandidateID, @JobOrderID";

            object[] parm =
            {
                new SqlParameter("@CandidateSource", candidateSource),
                new SqlParameter("@CandidateID", candidateId),
                new SqlParameter("@JobOrderID", jobOrderId ?? (object)DBNull.Value),
            };

            return _appDbContext.Set<HrCandidatePublicDTO>().FromSqlRaw(qry, parm).AsEnumerable().FirstOrDefault();
        }

        public HrCandidatePublicDTO GetRecordByCD(string code)
		{
            var entry = _appDbContext.HrCandidates.Where(c => c.UserName == code).FirstOrDefault();
            return GetRecordByID("A", entry.CandidateID, null);
        }

        public List<HrCandidatePublicDTO> Search(HrCandidateParmDTO searchParms)
        {
            string qry = "EXEC[HRMTalentSearch] @Keyword, @Country, @Location, @Title, @JobIndustry, @CandidateSource, @CandidateID";

            object[] parm =
            {
                new SqlParameter("@Keyword", searchParms.Keyword),
                new SqlParameter("@Country", searchParms.Country),
                new SqlParameter("@Location", searchParms.Location),
                new SqlParameter("@Title", searchParms.Title),
                new SqlParameter("@JobIndustry", searchParms.JobIndustry ?? (object)DBNull.Value),
                new SqlParameter("@CandidateSource", searchParms.CandidateSource?? (object)DBNull.Value),
                new SqlParameter("@CandidateID", searchParms.CandidateID?? (object)DBNull.Value),
            };

            var candList = _appDbContext.Set<HrCandidatePublicDTO>().FromSqlRaw(qry, parm).AsEnumerable().ToList();
            candList.ForEach(x => x.DynmcImageUrl = _cdnFileService.GetCandidateProfileImageUrl(x.ProfileImgKey));
            return candList;
        }

    }
}
