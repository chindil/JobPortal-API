using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Api.Hrm.Services;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.CRM;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Controllers.CRM
{
    [Route("v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
    [ApiController]
	//[ApiExplorerSettings(IgnoreApi = Shared.Api.InternalConfig.SwaggerDocs.IsHideAtsApi)]
	public class CorporateController : ControllerBase
    {
        private readonly ICorporateRepository _IRepository;

        public CorporateController(ICorporateRepository iRepository)
        {
            _IRepository = iRepository;
        }

		// GET: v1.0/<CandidateController>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get()
		{
			return Ok(_IRepository.GetAllRecords());
		}

		// GET api/<CandidateController>/5
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get(int id)
		{
			if (id == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id})");
			}


			var rec = _IRepository.GetRecordByID(id);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The corporate entity does not exists.");
			}
			return Ok(rec);
		}

		// POST api/<CandidateController>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public IActionResult Post([FromBody] Corporate value)
		{
			var createdEntry = _IRepository.UpdateRecord(value, Shared.Status.EntryState.Update, "");

			return Created("candidate", createdEntry);
		}

		// PUT api/<CandidateController>/5
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Put(int id, [FromBody] Corporate value)
		{
			if (value == null)
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");

			_IRepository.UpdateRecord(value, Shared.Status.EntryState.New, "");

			return Ok(); //success
		}

        [HttpPost("CompanyLogo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public async Task<IActionResult> PostProfileImage(IFormFile file, int candidateId)
        {
            if (file == null)
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, "No file received from the upload.");
            try
            {
                candidateId = HttpContext.GetClaimUserID();
                if (candidateId <= 0)
                    return HttpResponseHelper.GetResponse(HttpResponseHelper.ResponseType.CandidateInvalid);
                if (!Shared.Api.Services.FileStorageHelper.IsImage(file))
                    return HttpResponseHelper.GetResponse(HttpResponseHelper.ResponseType.ContentTypeInvalid);

                var imageFilename = FileService.GetNewFilename(file.FileName, candidateId.ToString());
                var isUploaded = await _IRepository.UpdateProfileLogo(file, imageFilename, candidateId);

                if (!isUploaded)
                {
                    return HttpResponseHelper.GetResponse(HttpStatusCode.UnsupportedMediaType, $"The candidate entity has not been updated properly or the entry does not exists.");
                }

                return Ok(isUploaded);
            }
            catch (Exception ex)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Delete(int id)
		{
			return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");

            //if (id == 0)
            //{
            //	var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            //	{
            //		Content = new StringContent($"The provided value is invalid ({id}).", System.Text.Encoding.UTF8, "text/plain"),
            //		StatusCode = HttpStatusCode.NotFound
            //	};
            //	return NotFound(response);
            //}

            //var entryToDelete = _IRepository.DeleteRecord(id, "");
            //if (entryToDelete == false)
            //{
            //	var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            //	{
            //		Content = new StringContent($"No valid record found.", System.Text.Encoding.UTF8, "text/plain"),
            //		StatusCode = HttpStatusCode.NotFound
            //	};
            //	return NotFound(response);
            //}

            //return Ok();//success
        }

	}
}
