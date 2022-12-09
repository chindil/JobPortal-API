using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Api.Services
{
    public class FileStorageHelper
    {
        public static bool IsImage(IFormFile file)
        {
            if (file.ContentType?.Contains("image") ?? false)
            {
                return true;
            }

            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsPdfOrDocFile(IFormFile file)
        {
            if (file.ContentType?.Contains("image")??false)
            {
                return true;
            }

            string[] formats = new string[] { ".pdf", ".docx", ".doc"};
            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}
