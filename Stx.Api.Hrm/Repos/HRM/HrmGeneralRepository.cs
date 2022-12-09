using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Api.Hrm.Interfaces;
using Stx.Shared;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.Repos.HRM
{
    public class HrmGeneralRepository : IHrmGeneralRepository
    {
        private readonly StxDbContext _appDbContext;

        public HrmGeneralRepository(StxDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<HrJobIndustry> GetJobIndustries()
        {
            return _appDbContext.HrJobIndustries.ToList();
        }

        public List<HrJobCategory> GetJobCategories()
        {
            return _appDbContext.HrJobCategories.ToList();
        }

        public HrJobCategory GetJobCategoriesById(int jobIndustryId)
        {
            return _appDbContext.HrJobCategories.FirstOrDefault(c => c.JobIndustryID == jobIndustryId);
        }

        public HrJobSpecialty GetJobSpecialtiesById(int jobCategoryId)
        {
            return _appDbContext.HrJobSpecialties.FirstOrDefault(c => c.JobCategoryID == jobCategoryId);
        }
    }
}
