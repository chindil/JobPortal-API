using Microsoft.AspNetCore.Http;
using Stx.Shared.Models.CRM;
using Stx.Shared.Status;
using System.Collections.Generic;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.Interfaces.CRM
{
    public interface ICorporateSettingsRepository
    {
        public string UpdateProfileImage(IFormFile file, string userId);

        public Corporate GetProfile(int id);
        public Corporate UpdateProfile(Corporate entry, string userId);

        public List<HrAtsDepartment> GetDepartments(int id);
        public HrAtsDepartment UpdateDepartments(HrAtsDepartment entry, string userId);

        public List<HrAtsTeamDTO> GetTeams(int id);
        public HrAtsTeamDTO UpdateTeams(HrAtsTeamDTO entry, List<HrAtsTeamJob> assignJobs, string userId);

        public List<HrAtsWorkflow> GetWorkflows(int id);
        public List<HrAtsWorkflow> UpdateWorkflows(List<HrAtsWorkflow> entry, string userId);

        public List<HrAtsMailTemplate> GetEmailTemplates(int id);
        public HrAtsMailTemplate UpdateEmailTemplates(HrAtsMailTemplate entry, string userId);

        public List<CorporateBenchmark> GetInterviewTools(int id);
        public List<CorporateBenchmark> UpdateInterviewTools(List<CorporateBenchmark> entries, string userId);

        /// <summary>
        /// Corporate Preference & Settings
        /// </summary>
        /// <param name="id">Corporate id</param>
        /// <returns></returns>
        public List<CorporatePreference> GetCorporatePreference(int id);
        public List<CorporatePreference> UpdateCorporatePreference(List<CorporatePreference> entries, string userId);

    }
}
