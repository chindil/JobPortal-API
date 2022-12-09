using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Infrastructure.Image
{
    public interface IImageHandler
    {
        ImgData GetImageData();
        string GetPhysicalFilePathFromData(short moduleId, string imageKey, string imageName);
        string GetPhysicalPathFromRelativeUrl(string url);
    }
}
