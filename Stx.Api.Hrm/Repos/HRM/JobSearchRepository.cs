using System.Collections.Generic;
using System.Linq;
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
    public class JobSearchRepository : IJobSearchRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly ICdnFileService _cdnFileService;

        public JobSearchRepository(StxDbContext appDbContext, 
            ILogger<JobOrderRepository> logger,
            ICdnFileService cdnFileService
            )
        {
            _appDbContext = appDbContext;
            _cdnFileService = cdnFileService;
        }


        public List<HrJobOrderSearch> Search(HrJobSearchParmDTO parm)
        {
            //return Search(parm.Keyword, parm.Location, string.Join(",", parm.JobIndustries), parm.CandidateID);
            //string qry = $"EXEC [HRMJobOrderSearch] @Keyword='{keyword}', @Location='{location}', @JobIndustry='{jobindustry}', @CandidateID={candidateid}, @SearchMode={ };

            string qry = $"EXECUTE [HRMJobOrderSearch] @SearchMode=@SearchMode, @CandidateID=@CandidateID, @CorporateID=@CorporateID, @Keyword=@Keyword, @Location=@Location, @JobIndustry=@JobIndustry," +
                $"@CareerLevels=@CareerLevels, @EmploymentTypes=@EmploymentTypes, @SalaryFrom=@SalaryFrom, @SalaryTo=@SalaryTo, @EmployerTypes=@EmployerTypes, @JobSpecialties=@JobSpecialties";
            var parameters = new SqlParameter[] 
            {
                new SqlParameter("SearchMode", parm.SearchMode),
                new SqlParameter("CandidateID", parm.CandidateID),
                new SqlParameter("CorporateID", parm.CorporateID),
                new SqlParameter("Keyword", parm.Keyword??""),
                new SqlParameter("Location", parm.Location??""),
                new SqlParameter("JobIndustry", string.Join(",", (parm.JobIndustries ?? new List<string>()))),
                new SqlParameter("CareerLevels", ""),
                new SqlParameter("EmploymentTypes", string.Join(",", (parm.EmploymentTypes ?? new List<short>()))),
                new SqlParameter("SalaryFrom", parm.SalaryFrom),
                new SqlParameter("SalaryTo", parm.SalaryTo),
                new SqlParameter("EmployerTypes", ""),
                new SqlParameter("JobSpecialties", parm.Specialty??""),
                };
            
            var jobs = _appDbContext.Set<HrJobOrderSearch>().FromSqlRaw(qry, parameters).AsEnumerable().ToList();
            jobs.ForEach(x => x.DynmcImageUrl = _cdnFileService.GetCompanyLogoUrl(x.LogoImgKey));
            return jobs;
        }

    }
}
