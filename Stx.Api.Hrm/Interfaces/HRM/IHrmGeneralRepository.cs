using System.Collections.Generic;
using Stx.Shared;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.Interfaces
{
    public interface IHrmGeneralRepository
    {
        List<HrJobIndustry> GetJobIndustries();

        List<HrJobCategory> GetJobCategories();
        HrJobCategory GetJobCategoriesById(int jobIndustryId);

        HrJobSpecialty GetJobSpecialtiesById(int jobCategoryId);
    }
}
