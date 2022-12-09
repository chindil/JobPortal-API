using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.Collective;
using Stx.Shared.Models.CRM;
using Stx.Shared.Models.HRM;
using System.Collections.Generic;
using System.Net;

namespace Stx.Api.Hrm.Controllers.CRM
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = Shared.Api.InternalConfig.SwaggerDocs.IsHideAtsApi)]
	public class CorporateSettingsController : Controller
	{
		private readonly ICorporateSettingsRepository _IRepository;

		public CorporateSettingsController(ICorporateSettingsRepository iRepository)
		{
			_IRepository = iRepository;
		}

		/// <summary>
		/// Upload Images (Profile, Logo, Banner etc) 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		[HttpPost("Profile/Upload/{key:int}")]
		public IActionResult Upload(int key)
		{
			try
			{
				var file = Request.Form.Files[0];

				if (file == null)
					return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

				var entry = _IRepository.UpdateProfileImage(file, key.ToString());
				if (entry == null)
				{
					return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The content is not available.");
				}
				return Ok(entry);

			}
			catch (System.Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex}");
			}
		}


		[HttpGet("Profile/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetProfile(int id)
		{
			return Ok(_IRepository.GetProfile(id));
		}

        [HttpPost("Profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateProfile([FromBody] Corporate value)
        {
            if (value == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			var entry = _IRepository.UpdateProfile(value, "");
            if (entry == null)
            {
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The content is not available.");
            }
            return Ok(entry);
        }

		[HttpGet("Departments/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult GetDepartments(int id)
		{
			var list = _IRepository.GetDepartments(id);
			if (list == null)
			{
				return Ok(new HrAtsDepartment());
			}
			return Ok(list);
		}

		[HttpPost("Departments")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult UpdateDepartments([FromBody] HrAtsDepartment entry, string userId)
		{
			if (entry == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			var ret = _IRepository.UpdateDepartments(entry, "");
			if (ret == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The content is not available.");
			}
			return Ok(ret);
		}

		[HttpGet("Teams/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult GetTeams(int id)
		{
			var list = _IRepository.GetTeams(id);
			if (list == null)
			{
				return Ok(new HrAtsTeamDTO());
			}
			return Ok(list);
		}

		[HttpPost("Teams")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult UpdateTeams([FromBody] CorporateTeamCollective entry, string userId)
		{
			if (entry == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			var ret = _IRepository.UpdateTeams(entry.AtsTeam, entry.AtsTeamAssignJobs, "");
			if (ret == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The content is not available.");
			}
			return Ok(ret);
		}

		[HttpGet("CorporatePreference/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult GetCorporatePreference(int id)
		{
			var list = _IRepository.GetCorporatePreference(id);
			if (list == null)
			{
				return Ok(new HrAtsTeamDTO());
			}
			return Ok(list);
		}

		[HttpPost("CorporatePreference")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult UpdateCorporatePreference([FromBody] List<CorporatePreference> entry, string userId)
		{
			if (entry == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			var ret = _IRepository.UpdateCorporatePreference(entry, "");
			if (ret == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The content is not available.");
			}
			return Ok(ret);
		}


		[HttpGet("Workflows/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult GetWorkflows(int id)
		{
			var list = _IRepository.GetWorkflows(id);
			if (list == null)
			{
				return Ok(new List<HrAtsWorkflow>());
			}
			return Ok(list);
		}

		[HttpPost("Workflows")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult UpdateWorkflows([FromBody] List<HrAtsWorkflow> entry, string userId)
		{
			if (entry == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			var ret = _IRepository.UpdateWorkflows(entry, "");
			if (ret == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The content is not available.");
			}
			return Ok(ret);
		}


		[HttpGet("EmailTemplates/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult GetEmailTemplates(int id)
		{
			var list = _IRepository.GetEmailTemplates(id);
			if (list == null)
			{
				return Ok(new HrAtsTeamDTO());
			}
			return Ok(list);
		}

		[HttpPost("EmailTemplates")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult UpdateEmailTemplates([FromBody] HrAtsMailTemplate entry, string userId)
		{
			if (entry == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			var ret = _IRepository.UpdateEmailTemplates(entry, "");
			if (ret == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The content is not available.");
			}
			return Ok(ret);
		}


		/// <summary>
		/// Interview tools & templates (CorporateBenchmark tools) 
		/// </summary>
		/// <param name="id">Corporate id</param>
		/// <returns></returns>
		[HttpGet("CorporateBenchmark/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult GetCorporateBenchmark(int id)
		{
			var list = _IRepository.GetInterviewTools(id);
			if (list == null)
			{
				return Ok(new HrAtsTeamDTO());
			}
			return Ok(list);
		}

		/// <summary>
		/// Update interview tools & templates (CorporateBenchmark tools) 
		/// </summary>
		/// <param name="entry">CorporateBenchmark entry</param>
		/// <param name="userId">current user id</param>
		/// <returns></returns>
		[HttpPost("CorporateBenchmark")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult UpdateCorporateBenchmark([FromBody] List<CorporateBenchmark> entry, string userId)
		{
			if (entry == null || entry.Count == 0)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			var ret = _IRepository.UpdateInterviewTools(entry, "");
			if (ret == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The content is not available.");
			}
			return Ok(ret);
		}


	}
}
