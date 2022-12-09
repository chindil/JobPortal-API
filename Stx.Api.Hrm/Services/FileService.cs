using Stx.Shared.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Services
{
    public class FileService
    {
        public static string GetNewFilename(string oldFileName, string newFileName)
        {
            return $"{newFileName}{System.IO.Path.GetExtension(oldFileName)}";
        }

        public static string GetNewFilenameWithPrefix(string prefix, string originalFileName, int maxLengthFromOrgFileName, string postfix, string separator="")
        {
            //Format: [CandidateID]_[OldFileName 15char].extension
            return $"{prefix}" +
                $"{separator}" +
                $"{System.IO.Path.GetFileNameWithoutExtension(originalFileName).Left(maxLengthFromOrgFileName)}" +
                $"{separator}" +
                $"{postfix}" +
                $"{System.IO.Path.GetExtension(originalFileName)}";
        }
    }
}
