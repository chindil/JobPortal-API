using Microsoft.AspNetCore.Identity;

namespace Stx.Api.Hrm.Repos
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CandidateID { get; set; }
        public int? CorporateID { get; set; }
    }
}
