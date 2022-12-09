using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.Parm;
using System.Net;

/// <summary>
/// Candidate-Public are the job seekers in ATS. Shows only the job seekers' public data.
/// </summary>
namespace Stx.Api.Hrm.Controllers.Hrm
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
	//[Authorize(Policy = "JobOwner")]
	public class CandidatePublicController : ControllerBase
	{
		private readonly ICandidatePublicRepository _IRepository;


		public CandidatePublicController(ICandidatePublicRepository iRepository)
		{
			_IRepository = iRepository;
		}
			
		[HttpGet("{candidateId:int}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]	
		public IActionResult Get(int candidateId)
		{
			if (candidateId == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({candidateId}).");
			}

			var rec = _IRepository.GetRecordByID(candidateId);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity does not exists.");
			}
			return Ok(rec);
		}

		[HttpGet("{candidateSource}/{candidateId:int}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get(string candidateSource, int candidateId)
		{
			if (candidateId == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({candidateId}).");
			}

			var rec = _IRepository.GetRecordByID(candidateSource, candidateId);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, "The candidate entity does not exists.");
			}
			return Ok(rec);
		}	
		
		[HttpGet("{candidateSource}/{candidateId:int}/{jobOrderId:int}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get(string candidateSource, int candidateId, int jobOrderId)
		{
			if (candidateId == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({candidateId}).");
			}

			var rec = _IRepository.GetRecordByID(candidateSource, candidateId, jobOrderId);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, "The candidate entity does not exists.");
			}
			return Ok(rec);
		}

		[HttpGet("{code}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetByCD(string code)
		{
			if (string.IsNullOrWhiteSpace(code))
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({code}).");
			}

			code = System.Uri.UnescapeDataString(code);
			var rec = _IRepository.GetRecordByCD(code);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, "The candidate entity does not exists.");
			}
			return Ok(rec);
		}

		[HttpPost("Search/")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public IActionResult Search([FromBody] HrCandidateParmDTO value)
		{
			var entries = _IRepository.Search(value);
			return Ok(entries);
		}

	}
}
