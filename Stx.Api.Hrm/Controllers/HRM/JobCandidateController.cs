using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stx.Api.Hrm.Controllers.Hrm
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
	//[Authorize(Policy = "JobOwner")]
	[ApiExplorerSettings(IgnoreApi = Shared.Api.InternalConfig.SwaggerDocs.IsHideAtsApi)]
	public class JobCandidateController : ControllerBase
	{
		private readonly IJobCandidateRepository _IRepository;

		public JobCandidateController(IJobCandidateRepository iRepository)
		{
			_IRepository = iRepository;
		}
			
		[HttpGet("{jobCandidateId:int}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]	
		public IActionResult Get(int jobCandidateId)
		{
			if (jobCandidateId == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({jobCandidateId}).");
			}

			var rec = _IRepository.GetRecordByID(jobCandidateId);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity does not exists.");
			}
			return Ok(rec);
		}

        [HttpGet("Stage/{candidateStage}/{jobOrderId:int}")]
        //[Authorize(Policy = "JobRecruiter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByStage(string candidateStage, int jobOrderId)
        {
            if (jobOrderId <= 0)
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({jobOrderId}).");
            }

            var rec = _IRepository.GetRecordListByStage(candidateStage, jobOrderId);
            if (rec == null)
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity does not exists.");
            }
            return Ok(rec);
        }

        [HttpPost("Search/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Search([FromBody] HrJobCandidateParmDTO value)
        {
            var entries = _IRepository.Search(value);
            return Ok(entries);
        }

        [HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Put([FromBody] HrJobCandidate value)
		{
			if (value == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			_IRepository.UpdateRecord(value, Shared.Status.EntryState.New, "");

			return Ok(); //success
		}

	}
}
