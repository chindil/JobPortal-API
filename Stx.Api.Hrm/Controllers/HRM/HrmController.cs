using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces;
using Stx.Shared.Bps;
using Stx.Shared.Common;
using Stx.Shared.Status;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stx.Api.Hrm.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
	public class HrmController : ControllerBase
	{
        private readonly IHrmGeneralRepository _IHrmGeneralRepository;

        public HrmController(IHrmGeneralRepository hrmGeneralRepository)
        {
            _IHrmGeneralRepository = hrmGeneralRepository;
        }

        //eg: HrJobIndustry (IT, Finance..)
        [HttpGet]
        [Route("JobIndustries")]
        public IActionResult GetJobIndustries()
        {
            return Ok(_IHrmGeneralRepository.GetJobIndustries());
        }

        //eg: HrJobCategory (Programming, Analyst, Team Lead,...)
        [HttpGet]
        [Route("JobCategories")]
        public IActionResult GetJobCategories()
        {
            return Ok(_IHrmGeneralRepository.GetJobCategories());
        }

        //eg: HrJobCategory (Programming, Analyst, Team Lead,...)
        [HttpGet]
        //[HttpGet("{id:int}")]
        [Route("JobCategoriesById/{id}")]
        public IActionResult GetJobCategoriesById(int id)
        {
            return Ok(_IHrmGeneralRepository.GetJobCategoriesById(id));
        }

        // eg: HrJobSpecialty (Java, C#...)
        [HttpGet]
        //[HttpGet("{id:int}")]
        [Route("JobSpecialtiesById/{id}")]
        public IActionResult GetJobSpecialtiesById(int id)
        {
            return Ok(_IHrmGeneralRepository.GetJobSpecialtiesById(id));
        }

    }
}
