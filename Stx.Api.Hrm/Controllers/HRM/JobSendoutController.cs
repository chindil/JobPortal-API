using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.HRM;
using System.Net;

namespace Stx.Api.Hrm.Controllers.HRM
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
	public class JobSendoutController : ControllerBase
	{
		private readonly IJobSendoutRepository _IRepository;

		public JobSendoutController(IJobSendoutRepository iRepository)
		{
			_IRepository = iRepository;
		}

		[HttpGet("{jobOrderId:int}/{candidateId:int}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get(int jobOrderId, int candidateId)
		{
			var ret = _IRepository.GetJobSubmitData(jobOrderId, candidateId);
			if (ret == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"No valid record found.");
			}

			return Ok(ret);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Post([FromBody] HrJobSendout jobSendout)
		{
			var ret = _IRepository.Submit(jobSendout, "");
			if (ret == null || !ret.IsSuccess)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"Invalid record.");
            }

			return Ok(true);
		}
	}
}
