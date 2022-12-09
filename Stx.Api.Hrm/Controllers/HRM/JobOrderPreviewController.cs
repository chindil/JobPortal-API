using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.DTO.HRM;
using System;
using System.Net;
using System.Security.Claims;

namespace Stx.Api.Hrm.Controllers.HRM
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
	public class JobOrderPreviewController : ControllerBase
    {
		private readonly IJobOrderPreviewRepository _IRepository;

		public JobOrderPreviewController(IJobOrderPreviewRepository iRepository)
		{
			_IRepository = iRepository;
		}

		[AllowAnonymous]
		[HttpGet("{id}/{candidateid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get(int id, int candidateid)
		{
			if (id == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");
			}

			var rec = _IRepository.GetRecordByID(id, candidateid);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The job entity does not exists.");
			}
			return Ok(rec);
		}

		
		[HttpPost("Action")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public IActionResult Action([FromBody] CandidateJobOrderActionDto actionDto)
		{
			actionDto.CandidateID = HttpContext.GetClaimUserID();
			if (actionDto.JobOrderID <= 0 || string.IsNullOrWhiteSpace(actionDto.ActionName) || string.IsNullOrWhiteSpace(actionDto.ActionValue))
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided values are invalid.");
			}

			var result = _IRepository.Action(actionDto);

			if(string.IsNullOrWhiteSpace(result))
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"No valid action to proccess.");
			}
			return Created("actionsuccess", result);
		}
	}
}
