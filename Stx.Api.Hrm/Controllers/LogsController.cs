using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Stx.Api.Hrm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogsController : Controller
    {
        private IWebHostEnvironment _WebHostEnv;
        public LogsController(IWebHostEnvironment webHostEnvironment)
        {
            _WebHostEnv = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string logpath = AppContext.BaseDirectory;
            logpath = System.IO.Path.Combine(logpath, $"Logs\\ApiLog-all-{DateTime.Now.ToString("yyyy-MM-dd")}.log");
            ViewBag.Message = System.IO.File.ReadAllText(logpath);
            return View("Logs");
        }

        [HttpGet("Clear")]
        public IActionResult ClearLogs()
        {
            string logpath = AppContext.BaseDirectory;
            logpath = System.IO.Path.Combine(logpath, $"Logs\\ApiLog-all-{DateTime.Now.ToString("yyyy-MM-dd")}.log");
            System.IO.File.Delete(logpath);
            return View("Logs");
        }
    }
}
