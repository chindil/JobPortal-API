using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Api.Hrm.Services;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Candidates are the job seekers in the job portal.  
/// </summary>
namespace Stx.Api.Hrm.Controllers.Hrm
{
    [ApiController]
	[ApiVersion("1.0")]
	[Route("v{version:apiVersion}/[controller]")]
	[Authorize(Policy = "PolicyCandidate")]
	public class CandidateController : ControllerBase
	{
		private readonly ICandidateRepository _ICandidateRepository;
        private readonly ILogger<CandidateController> _Logger;

        public CandidateController(ICandidateRepository iRepository, ILogger<CandidateController> logger)
		{
			_ICandidateRepository = iRepository;
			_Logger = logger;
		}

		[HttpGet]
		//[Authorize(Policy = "JobOwner")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get()
		{
			var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

			var claims = User.Claims.Select(x => $"{x.Type}:{x.Value}").ToList();

			return Ok(_ICandidateRepository.GetAllRecords());			
		}

		[HttpGet("{id:int}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get(int id)
		{
			if (id == 0)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");
			}

			var rec = _ICandidateRepository.GetRecordByID(id);
			if (rec == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity does not exists.");
			}
			return Ok(rec);
		}
			

		[HttpGet("{code}")]
		//[Route("CandidateByCD")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetByCD(string code)
		{
			if (string.IsNullOrWhiteSpace(code))
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({code}).");
			}

			code = System.Uri.UnescapeDataString(code);
			var rec = _ICandidateRepository.GetRecordByCD(code);
			if (rec == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity does not exists.");
			}
			return Ok(rec);
		}
			

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public IActionResult Post([FromBody] HrCandidate value)
		{
			var createdEntry = _ICandidateRepository.UpdateRecord(value, Shared.Status.EntryState.Update, "");

			return Created("candidate", createdEntry);
		}

		[HttpPut("{updateDivCode}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Put(string updateDivCode, [FromBody] HrCandidate entry)
		{
			if (entry == null)
				return NotFound();

			var rec = _ICandidateRepository.PartialUpdateRecord(entry, updateDivCode, "");
			if (rec == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity does not exists.");
			}
			return Ok(rec); //success
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Delete(int id)
		{
			if (id == 0)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({id}).");
			}

			var entryToDelete = _ICandidateRepository.DeleteRecord(id, "");
			if (entryToDelete == false)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"No valid record found.");
			}

			return Ok();//success
		}

		#region Get Other Candidate/job data -------------------

		[HttpGet("Lists/{candidateId:int}/{listCode}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetStatLists(int candidateId, string listCode)
		{
			if (string.IsNullOrWhiteSpace(listCode) || candidateId <= 0)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value(s) are invalid.");
			}

			var rec = _ICandidateRepository.GetCandidateJobStats(candidateId, listCode);
			if (rec == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The entities may not available.");
			}
			return Ok(rec);
		}
		#endregion

		#region Update Other Candidate/job data -------------------

		[HttpPost("Stat/{candidateId:int}/{jobId:int}/{statType}/{statValue}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult UpdateCandidateStat(int candidateId, int jobId, string statType, string statValue)
		{
			if (string.IsNullOrWhiteSpace(statValue) || candidateId <= 0|| jobId <= 0)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value(s) are invalid.");
			}

			var rec = _ICandidateRepository.UpdateCandidateStat(candidateId, jobId, statType, statValue);
			if (rec == false)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The record may not exists.");
			}
			return Ok(rec);
		}
		#endregion

		#region Candidate Resume - Partial Get/Updates/Delete -------------------

		[HttpGet("Resume/{candidateId:int}/{recId:int}/{listCode}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetResumeSection(int candidateId, int recId, string listCode)
		{
			if (candidateId == 0)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid ({candidateId}).");
			}

            switch (listCode)
            {
				case "Experiences":
					return Ok(_ICandidateRepository.GetExperiences(candidateId, recId));
				case "Educations":
					return Ok(_ICandidateRepository.GetEducations(candidateId, recId));
				case "Certificates":
					return Ok(_ICandidateRepository.GetCertificates(candidateId, recId));
				case "Skills":
					return Ok(_ICandidateRepository.GetSkills(candidateId, recId));
				case "Languages":
					return Ok(_ICandidateRepository.GetLanguages(candidateId, recId));
				default:
				{
					return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity does not exists.");
				}
            }
		}



		/// <summary>
		/// Update candidate's experiences 
		/// </summary>
		/// <param name="entry">HrCandidateExperience</param>
		/// <returns></returns>
		[HttpPost("Experiences/")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult UpdateExperience([FromBody] HrCandidateExperience entry)
		{
			if (entry == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided data is invalid.");
			}

			var rec = _ICandidateRepository.UpdateExperiences(entry);
			if (rec == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate experience entity does not exists.");
			}
			return Ok(rec);
		}


		/// <summary>
		/// Update candidate's education 
		/// </summary>
		/// <param name="entry">HrCandidateEducation</param>
		/// <returns></returns>
		[HttpPost("Educations/")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult UpdateEducation([FromBody] HrCandidateEducation entry)
		{
			if (entry == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided data is invalid.");
			}

			var rec = _ICandidateRepository.UpdateEducations(entry);
			if (rec == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate experience entity does not exists.");
			}
			return Ok(rec);
		}


		/// <summary>
		/// Update candidate's certificate 
		/// </summary>
		/// <param name="entry">HrCandidateCertificate</param>
		/// <returns></returns>
		[HttpPost("Certificates/")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult UpdateCertificates([FromBody] HrCandidateCertificate entry)
		{
			if (entry == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided data is invalid.");
			}

			var rec = _ICandidateRepository.UpdateCertificates(entry);
			if (rec == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate education entity does not exists.");
			}
			return Ok(rec);
		}

		/// <summary>
		/// Update candidate's skills 
		/// </summary>
		/// <param name="entry">Skills as HrCandidateSkill</param>
		/// <returns></returns>
		[HttpPost("Skills/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateSkills([FromBody] List<HrCandidateSkill> entry)
        {
            if (entry == null)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided data is invalid.");
            }

            var rec = _ICandidateRepository.UpdateSkills(entry);
            if (rec == null)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate education entity does not exists.");
            }
            return Ok(rec);
        }

		/// <summary>
		/// Update candidate's languages  
		/// </summary>
		/// <param name="entry">Language skills as HrCandidateSkill</param>
		/// <returns></returns>
		[HttpPost("Languages/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateLanguages([FromBody] List<HrCandidateLanguage> entry)
        {
            if (entry == null)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided data is invalid.");
            }

            var rec = _ICandidateRepository.UpdateLanguages(entry);
            if (rec == null)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, "The candidate education entity does not exists.");
            }
            return Ok(rec);
        }


		/// <summary>
		/// Delete resume component (cert, edu, exp) 
		/// </summary>
		/// <param name="docType">Doc Type (CERT, EDUC, EXPE) </param>
		/// <param name="candidateId"> Candidate Id</param>
		/// <param name="recId"> Record id </param>
		/// <returns></returns> {candidateId:int}
		[HttpDelete("Resume/{docType}/Delete/{candidateId:int}/{recId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteResumeComponent(string docType, int candidateId, int recId)
		{
			if (candidateId <= 0 || recId <= 0)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided data is invalid.");
			}

			var rec = _ICandidateRepository.DeleteResumeComponent(docType, candidateId, recId);
			if (rec == null)
			{
                return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The resume component does not exists.");
			}
			return Ok(rec??false);
		}

		#endregion

		#region MultiData (eg: multiple-resumes)
		[HttpGet("MultiData/{CandidateId}/{recordType}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult GetCandidateMultiData(int candidateId, string recordType)
		{
			if (string.IsNullOrWhiteSpace(recordType) || candidateId <= 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value '{candidateId},{recordType}' is invalid.");
			}

			var rec = _ICandidateRepository.GetCandidateMultiData(candidateId, recordType);
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpResponseHelper.ResponseType.RecordNotFound);
			}
			return Ok(rec);
		}

		[HttpPost("MultiData/{isDropAndCreate:bool}")]
		//[Authorize(Policy = "JobRecruiter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult UpdateCandidateMultiData([FromBody] List<HrCandidateMultiData> candidateMultiDatas, bool isDropAndCreate)
		{
			if (candidateMultiDatas == null || candidateMultiDatas.Count == 0)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The provided value is invalid.");
			}

			var rec = _ICandidateRepository.UpdateCandidateMultiData(candidateMultiDatas, isDropAndCreate ? "DropAll" : "");
			if (rec == null)
			{
				return HttpResponseHelper.GetResponse(HttpResponseHelper.ResponseType.RecordNotFound);
			}
			return Ok(rec);
		}
		
		[HttpPost("ResumeFile/Upload")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> PostResumeFile([FromForm] IFormFileCollection data, [FromForm] string candidateMultiDatas)
		{
            List<HrCandidateMultiData> candMultiDataLst = JsonSerializer.Deserialize<List<HrCandidateMultiData>>((string)candidateMultiDatas);
            if (data == null || data.Count == 0)
                return HttpResponseHelper.GetResponse(HttpStatusCode.BadRequest, "No file(s) received from the upload.");
			if (candMultiDataLst == null || candMultiDataLst.Count <= 0)
				return HttpResponseHelper.GetResponse(HttpStatusCode.BadRequest, "Request data incomplete.");
			
			if(data.All(x=> !Shared.Api.Services.FileStorageHelper.IsPdfOrDocFile(x)))
            {
				return HttpResponseHelper.GetResponse(HttpResponseHelper.ResponseType.ContentTypeInvalid);
			}
			try
            {
                var candidateId = HttpContext.GetClaimUserID();
                if (candidateId <= 0)
                    return HttpResponseHelper.GetResponse(HttpResponseHelper.ResponseType.CandidateInvalid);

                var isUploaded = await _ICandidateRepository.UploadResumeFile(candidateId, data, candMultiDataLst);

                if (!isUploaded)
                {
                    return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The candidate entity has not been updated properly or the entry does not exists.");
                }

                return Ok(isUploaded);
            }
			catch(ArgumentException aex)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.BadRequest, aex.Message);
            }
            catch (Exception ex)
            {
                return HttpResponseHelper.GetResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
		}
		
		[HttpDelete("ResumeFile/Delete/{candidateId:int}/{filenName}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DeleteResumeFile(int candidateId, string filenName)
		{
			try
			{
				candidateId = HttpContext.GetClaimUserID();
				if (candidateId <= 0)
					return HttpResponseHelper.GetResponse(HttpResponseHelper.ResponseType.CandidateInvalid);
				if(string.IsNullOrWhiteSpace(filenName))
					return HttpResponseHelper.GetResponse(HttpResponseHelper.ResponseType.ProvidedValueInvalid);

				var isDeleted = await _ICandidateRepository.DeleteResumeFile(candidateId, filenName);

				if (!isDeleted)
				{
					return HttpResponseHelper.GetResponse(HttpStatusCode.NotFound, $"The file has not been deleted.");
				}

				return Ok(isDeleted);
			}
			catch (Exception ex)
			{
				return HttpResponseHelper.GetResponse(HttpStatusCode.InternalServerError, ex.Message);
			}
		}
		#endregion


	}
}
