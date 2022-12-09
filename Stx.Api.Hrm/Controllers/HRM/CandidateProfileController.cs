using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Api.Hrm.Services;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Api.Interfaces;
using Stx.Shared.Models.HRM;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Controllers.HRM
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    //[Authorize(Policy = "PolicyCandidate")]
    public class CandidateProfileController : ControllerBase
    {
        private readonly ICandidateProfileRepository _IRepository;

        public CandidateProfileController(ICandidateProfileRepository iRepository)
        {
            _IRepository = iRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");
            }
            var rec = _IRepository.GetRecordByID(id);
            if (rec == null)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity does not exists.");
            }
            return Ok(rec);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] HrCandidateProfile value)
        {
            var createdEntry = _IRepository.UpdateRecord(value, Shared.Status.EntryState.Update, "");

            if (createdEntry == null)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity has not been updated properly or the entry does not exists.");
            }

            return Created("candidateprofile", createdEntry);
        }

        [HttpPost("ProfileImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public async Task<IActionResult> PostProfileImage([FromForm] IFormFile data, [FromForm] int candidateId)
        {
            if (data == null)
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, "No file received from the upload.");
            try
            {
                candidateId = HttpContext.GetClaimUserID();
                if(candidateId <= 0)
                    return HttpResponseHelper.GetResponse( HttpResponseHelper.ResponseType.CandidateInvalid);
                if (!Shared.Api.Services.FileStorageHelper.IsImage(data))
                    return HttpResponseHelper.GetResponse( HttpResponseHelper.ResponseType.ContentTypeInvalid);

                var isUploaded = await _IRepository.UpdateProfileImage(data, candidateId);

                if (!isUploaded)
                {
                    return HttpResponseHelper.GetResponse(HttpStatusCode.UnsupportedMediaType, $"The candidate entity has not been updated properly or the entry does not exists.");
                }

                return Ok(isUploaded);
            }
            catch(Exception ex)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
