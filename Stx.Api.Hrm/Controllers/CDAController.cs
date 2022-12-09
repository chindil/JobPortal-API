using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Infrastructure.Image;
using Stx.Api.Hrm.Interfaces;
using Stx.Shared;
using Stx.Shared.Bps;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Ips;
using Stx.Shared.Status;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stx.Api.Hrm.Controllers
{
    /// <summary>
    /// Content delivery API (internal). eg: to deliver the images
    /// </summary>
	[ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CDAController : ControllerBase
    {
        //private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly ILogger<CDAController> _Logger;
        public static IImageHandler _imageHandler;

        public CDAController(IWebHostEnvironment webHostEnvironment, IImageHandler imageHandler, ILogger<CDAController> logger)
        {
            _imageHandler = imageHandler;
            _Logger = logger;
            //_WebHostEnvironment = webHostEnvironment;

        }

        [HttpGet]
        public IActionResult Get(short puid, string key, string name = "")
        {
            try
            {
                //Byte[] bte;
                if (puid <= 0 || string.IsNullOrWhiteSpace(key))
                {
                    return NoContent();
                }
                else if (puid.InShort(10, 11))
                {
                    return NoContent();
                }
                else if (puid >= 10 && puid <= 99)
                {
                    var path = _imageHandler.GetPhysicalFilePathFromData(puid, key, name);
                    if (System.IO.File.Exists(path))
                    { return PhysicalFile(path, "image/jpeg"); }
                    else
                    {
                        return NoContent();
                    }
                }
                else if (puid >= 100 && puid <= 199)
                {
                    var path = _imageHandler.GetPhysicalFilePathFromData(puid, key, name);
                    if (System.IO.File.Exists(path))
                    {
                        return PhysicalFile(path, "image/jpeg", "profileimg1700.jpg");
                    }
                    else
                    {
                        return NoContent();
                    }
                }
                else
                {
                    return Content("No action is defined for this id & key");
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Retrieving image file. {ex.Message}", ex);
                return NotFound("The resource cannot be found");
            }
        }

        [HttpGet("TestGetString")]
        public IActionResult TestGetString()
        {
            return Ok(new string[] { "This is a test string 1.", "This is a test string 2", "This is a test string 3" });
        }

    }
}
