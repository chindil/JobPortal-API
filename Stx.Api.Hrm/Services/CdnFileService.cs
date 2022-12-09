using Microsoft.Extensions.Options;
using Stx.Api.Hrm.Configurations;
using Stx.Api.Hrm.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Services
{
    public class CdnFileService : ICdnFileService
    {
        private readonly AzureStorageConfiguration _azureBlob = null;
        public CdnFileService(IOptionsMonitor<AzureStorageConfiguration> config)
        {
            _azureBlob = config.CurrentValue;

        }
        public string GetCandidateProfileImageUrl(string profileImgKey)
        {
            ValidateCandidateImageFile(ref profileImgKey);
            return $"{_azureBlob.CdnEndpointHostName}/{_azureBlob.CandidateProfileImgContainer}/{profileImgKey}";
        }

        public string GetCandidateProfileThumbnailUrl(string profileThumbImgKey)
        {
            ValidateCandidateImageFile(ref profileThumbImgKey);
            return $"{_azureBlob.CdnEndpointHostName}/{_azureBlob.CandidateProfileThumbsContainer}/{profileThumbImgKey}";
        }

        //Resume File
        public string GetCandidateResumeUrl(int candidateIdOrPath, string resumeNameKey)
        {
            return $"{_azureBlob.CdnEndpointHostName}/{_azureBlob.CandidateResumeContainer}/{candidateIdOrPath}/{resumeNameKey}";
        }

        public string GetCompanyLogoUrl(string profileImgKey)
        {
            ValidateCorporateLogoFile(ref profileImgKey);
            return $"{_azureBlob.CdnEndpointHostName}/{_azureBlob.CorporateLogoContainer}/{profileImgKey}";
        }

        public string GetCompanyLogoThumbnailUrl (string profileThumbImgKey)
        {
            ValidateCorporateLogoFile(ref profileThumbImgKey);
            return $"{_azureBlob.CdnEndpointHostName}/{_azureBlob.CorporateLogoThumbsContainer}/{profileThumbImgKey}";
        }

        #region VALIDATIONS
        private void ValidateCandidateImageFile(ref string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                filename = "_useravatar.png";
        }
        private void ValidateCorporateLogoFile(ref string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                filename = "_companyavatar.png";
        } 
        #endregion
    }
}
