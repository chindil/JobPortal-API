using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.DTO.HRM;
using System.Net;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Controllers.Hrm
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
	public class CandidateSignupController : ControllerBase
	{
		private readonly ICandidateSignupRepository _IRepository;

		public CandidateSignupController(ICandidateSignupRepository iRepository)
		{
			_IRepository = iRepository;
		}

		//// POST api/<CandidateController>
		//[HttpPost]
		//[ProducesResponseType(StatusCodes.Status201Created)]
		//public IActionResult Post([FromBody] HrCandidate value)
		//{
		//	var createdEntry = _IRepository.UpdateRecord(value, Shared.Status.EntryState.Edit, "");

		//	return Created("candidate", createdEntry);
		//}

		// PUT api/<CandidateController>/5
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Signup([FromBody] UserSignupDTO entry)
		{
			if (entry == null)
				return NotFound();

			var ret = await _IRepository.Signup(entry);
			if (!ret)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotImplemented, $"The user has not created.");
			}
			return Ok(ret); //success
		}

	}
}
