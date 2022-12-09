using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Interfaces.Services
{
    public interface ICdnFileService
    {
        string GetCandidateProfileImageUrl(string profileImgKey);
        string GetCandidateProfileThumbnailUrl(string profileThumbImgKey);
        string GetCandidateResumeUrl(int candidateIdOrPath, string resumeNameKey);

        string GetCompanyLogoUrl(string profileImgKey);
        string GetCompanyLogoThumbnailUrl(string profileThumbImgKey);

    }
}
