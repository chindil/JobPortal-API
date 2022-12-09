using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Infrastructure.Image
{
    public class ImageHandler : IImageHandler
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public ImageHandler(IWebHostEnvironment webHostEnvironment)
        {
            _WebHostEnvironment = webHostEnvironment;
        }
        
        public ImgData GetImageData()
        {
            return new ImgData() { FileName = "", ContentType = "" }; 
        }

        public string GetPhysicalFilePathFromData(short moduleId, string imageKey, string imageName)
        {
            string constName = "";
            if (moduleId >= 10 && moduleId <= 99) //IPS
            {
                constName = $"ips{moduleId}_{imageKey}{Path.GetExtension(imageName)}";
                var url = $"/Ips/Images/{moduleId}/{constName}";
                return GetPhysicalPathFromRelativeUrl(url);
            }
            else if (moduleId >= 100 && moduleId <= 199) //HRM JP
            {
                constName = $"hrm{moduleId}_{imageKey}{Path.GetExtension(imageName)}";
                var url = $"/Hrm/Images/{moduleId}/{constName}";
                return GetPhysicalPathFromRelativeUrl(url);
            }
            return null;
        }

        public string GetPhysicalPathFromRelativeUrl(string url)
        {
            var path = Path.Combine(_WebHostEnvironment.WebRootPath, url.TrimStart('/').Replace("/", "\\"));
            return path;
        }
    }
}
