using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Common;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Stx.Api.Hrm.Controllers.HRM
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
    //[Authorize(Policy = "test")]
	[ApiExplorerSettings(IgnoreApi = Shared.Api.InternalConfig.SwaggerDocs.IsHideAtsApi)]
	public class JobOrderController : ControllerBase
	{
		private readonly IJobOrderRepository _IRepository;

		public JobOrderController(IJobOrderRepository iRepository)
		{
			_IRepository = iRepository;
		}

		/// <summary>
		/// Get job order by job order id
		/// </summary>
		/// <param name="id">job order id</param>
		/// <returns></returns>
		[HttpGet("{id}")] 
		[ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");
            }

            var rec = _IRepository.GetRecordByID(id);
            if (rec == null)
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The job entity does not exists.");
            }

            return Ok(rec);
        }
		
		/// <summary>
		/// Get job order by job order id
		/// </summary>
		/// <param name="id">job order id</param>
		/// <returns></returns>
		[HttpGet("Summary/{id}")] 
		[ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetJobSummary(int id)
        {
            if (id == 0)
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");
            }

            var rec = _IRepository.GetJobSummaryByID(id);
            if (rec == null)
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The job entity does not exists.");
            }

            return Ok(rec);
        }

		/// <summary>
		/// Filter a list of job orders with details
		/// </summary>
		/// <param name="hrmParmDTO">Filter parameters </param>
		/// <returns></returns>
		[HttpPost("CorporateFilter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetByParm([FromBody] HrmParmDTO hrmParmDTO)
		{
			if (hrmParmDTO.EntryID1.ParmID <= 0 || !hrmParmDTO.FilterType.Compare(FilterType.CorpJobList.ToString()))
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");
			}

			var rec = _IRepository.GetCorporateJobList(hrmParmDTO.EntryID1.ParmID);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"No valid job entries found.");
			}
			return Ok(rec);

		}
		/// <summary>
		/// Filter a list of job orders with summary details (min list)
		/// </summary>
		/// <param name="hrmParmDTO">Filter parameters </param>
		/// <returns></returns>
		[HttpPost("CorporateFilter/Min")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetByParmMin([FromBody] HrmParmDTO hrmParmDTO)
		{
			if (hrmParmDTO.EntryID1.ParmID <= 0 || !hrmParmDTO.FilterType.Compare(FilterType.CorpJobList.ToString()))
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");
			}

			var rec = _IRepository.GetCorporateJobListMin(hrmParmDTO.EntryID1.ParmID);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"No valid job entries found.");
			}
			return Ok(rec);

		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public IActionResult Post([FromBody] HrJobOrder entry)
		{
			if (entry == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			var claims = HttpContext.GetClaimUserCorporateID();
			if (claims.UserID <= 0 || claims.CorpID <= 0 || entry.CorporateID != claims.CorpID)
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided values are invalid.");				
            }

			var createdEntry = _IRepository.UpdateRecord(entry, claims);

			return Ok(createdEntry);
		}


		[HttpPatch("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult PostQuery(int id, [FromBody] List<ParmStr> values)
		{
			string[] allowdCols = { "IsReqAutoRejectEmail", "AutoRejectEmailTemplate" };
			if (values.Where(x => !allowdCols.Contains(x.Value)).Count() > 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"All the queries are to pre-register before use.");
			}

			var updatedEntry = _IRepository.UpdateQuery(id, values, "");
			if(updatedEntry == null )
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"No valid job entries found.");
			}
			return Ok(updatedEntry);
		}

		// DELETE api/<CandidateController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Delete(int id)
		{
			if (id == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");
			}

			var entryToDelete = _IRepository.DeleteRecord(id, "");
			if (entryToDelete == false)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"No valid record found.");
			}

			return Ok();
		}


		#region Review Questions
		/// <summary>
		/// Get job order review questions
		/// </summary>
		/// <param name="id">job order id</param>
		/// <returns></returns>
		[HttpGet("ReviewQuestions/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetJobReviewQuestions(int id)
		{
			if (id == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");
			}

			var rec = _IRepository.GetReviewQuestions(id);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The job entity does not exists.");
			}

			return Ok(rec);
		}

		/// <summary>
		/// Update job order review questions
		/// </summary>
		/// <returns></returns>
		[HttpPost("ReviewQuestions")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult UpdateJobReviewQuestions(List<HrReviewQuestion> reviewQuestions)
		{
			if (reviewQuestions.Count == 0)
			{
				return Ok();
			}
			var createdEntry = _IRepository.UpdateReviewQuestions(reviewQuestions, "");
			return Ok(createdEntry);
		}

		/// <summary>
		/// Delete job order review question.
		/// </summary>
		/// <returns></returns>
		[HttpDelete("ReviewQuestions/{jobOrderId:int}/{Id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteJobReviewQuestions(int jobOrderId, int Id)
		{
			if (jobOrderId <= 0 || Id <= 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({jobOrderId}|{Id}).");
			}

			var entryToDelete = _IRepository.DeleteReviewQuestion(jobOrderId, Id);
			if (entryToDelete == false)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"No valid record found.");
			}

			return Ok();
		}
		#endregion

	}
}
