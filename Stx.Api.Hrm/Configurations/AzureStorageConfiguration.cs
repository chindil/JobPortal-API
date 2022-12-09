using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Configurations
{
    public class AzureStorageConfiguration  
    {
        //public string Url { get; set; }
        public string AccountKey { get; set; }
        public string CdnEndpointHostName { get; set; }
        public string CandidateProfileImgContainer { get; set; }
        public string CandidateProfileThumbsContainer { get; set; }
        public string CandidateResumeContainer { get; set; }

        public string CorporateLogoContainer { get; set; }
        public string CorporateLogoThumbsContainer { get; set; }
    }
}
