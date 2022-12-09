using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Stx.Shared;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Interfaces.HRM
 {
    public interface ICandidateRepository
    {
        public List<HrCandidate> GetAllRecords();

        public HrCandidate GetRecordByID(int id);
        ///// <summary>
        ///// Candidate info - Filtered-out data for public 
        ///// </summary>
        ///// <param name="id">Candidate Id</param>
        ///// <returns></returns>
        //public HrCandidate GetPublicCandidate(int id); << This is wrong. move this to a new "Job-Candidate" repository 

        public HrCandidate GetRecordByCD(string code);

        /// <summary>
        /// Get Candidate/candidate job stat lists (saved jobs, applied jobs)
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="listCode"></param>
        /// <returns></returns>
        public List<HrCandidateJobStatDTO> GetCandidateJobStats(int candidateId, string listCode);

        public List<HrCandidateMultiData> GetCandidateMultiData(int candidateId, string recordType);
        public List<HrCandidateMultiData> UpdateCandidateMultiData(List<HrCandidateMultiData> candidateMultiDatas, string dropAndCreateMode);

        public HrCandidate UpdateRecord(HrCandidate entry, EntryState entryState, string userId);
        public HrCandidate PartialUpdateRecord(HrCandidate entry, string updateDivCode, string userId);

        public List<HrCandidateExperience> GetExperiences(int candidateId, int recId);
        public List<HrCandidateEducation> GetEducations(int candidateId, int recId);
        public List<HrCandidateCertificate> GetCertificates(int candidateId, int recId);
        public List<HrCandidateSkill> GetSkills(int candidateId, int recId);
        public List<HrCandidateLanguage> GetLanguages(int candidateId, int recId);


        public HrCandidateExperience UpdateExperiences(HrCandidateExperience entry);
        public HrCandidateEducation UpdateEducations(HrCandidateEducation entry);
        public HrCandidateCertificate UpdateCertificates(HrCandidateCertificate entry);
        public List<HrCandidateSkill> UpdateSkills(List<HrCandidateSkill> entry);
        public List<HrCandidateLanguage> UpdateLanguages(List<HrCandidateLanguage> entry);

        public bool UpdateCandidateStat(int id, int jobOrderId, string statType, string statValue);

        public bool? DeleteRecord(int id, string userId);
        public bool? DeleteResumeComponent(string docType, int candidateId, int entryId);

        public Task<bool> UploadResumeFile(int candidateId, IFormFileCollection attachments, List<HrCandidateMultiData> fileUploadDtos);
        public Task<bool> DeleteResumeFile(int candidateId, string fileName);

    }
}
