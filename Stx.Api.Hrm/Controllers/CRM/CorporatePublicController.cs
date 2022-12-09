using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.CRM;
using Stx.Shared.Models.Parm;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Stx.Api.Hrm.Controllers.CRM
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
	public class CorporatePublicController : ControllerBase
    {
		private readonly ICorporatePublicRepository _IRepository;

		public CorporatePublicController(ICorporatePublicRepository iRepository)
		{
			_IRepository = iRepository;
		}

		[HttpGet("{id}/{candidateid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get(int id, int candidateid) //candidateid is used to save stats
		{
			if (id == 0)
			{
				//var response = new HttpResponseMessage(HttpStatusCode.NotFound)
				//{
				//	Content = new StringContent($"The provided value is invalid ({id}).", System.Text.Encoding.UTF8, "text/plain"),
				//	StatusCode = HttpStatusCode.NotFound
				//};
				//return NotFound(response); 


				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");

				//throw new WebHttp.HttpResponseException(response);
				//throw new StxException(null, "ERROR ffffffffffffffdfd fddfd fd.", HttpStatusCode.NotFound);
			}

			var rec = _IRepository.GetRecordByID(id, candidateid);
			if (rec == null)
			{
				var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
				{
					Content = new StringContent("The job entity does not exists.", System.Text.Encoding.UTF8, "text/plain"),
					StatusCode = System.Net.HttpStatusCode.NotFound
				};
				return NotFound(response);
			}

			return Ok(rec);
		}


		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize]
		public IActionResult Search([FromBody] HrJobSearchParmDTO hrJobSearchParm)
		{
			var rec = _IRepository.Search(hrJobSearchParm);
			if (rec == null)
			{
				rec = new List<CorporatePublicDTO>();
			}

			return Ok(rec);
		}

	}
}
