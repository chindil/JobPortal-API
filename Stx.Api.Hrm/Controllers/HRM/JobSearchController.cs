using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using System.Collections.Generic;

namespace Stx.Api.Hrm.Controllers.HRM
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
	[AllowAnonymous]
	public class JobSearchController : ControllerBase
	{
		private readonly IJobSearchRepository _IRepository;

		public JobSearchController(IJobSearchRepository iRepository)
		{
			_IRepository = iRepository;
		}
				
		[HttpGet("{keyword?}/{location?}/{jobindustry?}/{candidateid?}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get(string keyword=null, string location = null, string jobindustry = null, int candidateid = -1)
		{
			var rec = _IRepository.Search(new HrJobSearchParmDTO(keyword, location, new List<string> { jobindustry }, candidateid));
			if (rec == null)
			{
				rec = new List<HrJobOrderSearch>();
			}

			return Ok(rec);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult SearchPost([FromBody] HrJobSearchParmDTO hrJobSearchParm)
		{
			hrJobSearchParm.CandidateID = HttpContext.GetClaimUserID();
			var rec = _IRepository.Search(hrJobSearchParm);
			if (rec == null)
			{
				rec = new List<HrJobOrderSearch>();
			}

			return Ok(rec);
		}

	}
}
