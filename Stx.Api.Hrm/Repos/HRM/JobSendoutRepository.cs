using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Api.Hrm.Interfaces.Services;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Constants;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Repos.HRM
{
    public class JobSendoutRepository : IJobSendoutRepository
    {
        private readonly StxDbContext _appDbContext;
        private readonly ICdnFileService _cdnFileService;
        ILogger _logger;


        public JobSendoutRepository(StxDbContext appDbContext, ICdnFileService cdnFileService, ILogger<JobSendoutRepository> logger)
        {
            _appDbContext = appDbContext;
            _cdnFileService = cdnFileService;
            _logger = logger;
        }

        public HrJobSendoutDTO GetJobSubmitData(int jobOrderId, int candidateId)
        {
            var entiry = new HrJobSendoutDTO();
            var cand = _appDbContext.HrCandidates.Where(x => x.CandidateID == candidateId).FirstOrDefault();
            var job = _appDbContext.HrJobOrders.Where(x => x.JobOrderID == jobOrderId).FirstOrDefault();
            var resumes = _appDbContext.HrCandidateMultiDatas
                .Where(x => x.RecordType == HrCandidateMultiDataTypes.CandidateResumeFile && x.CandidateID == candidateId).ToList();
            if (candidateId == 0 && cand == null) cand = new HrCandidate();

            entiry.JobOrderID = jobOrderId;
            entiry.JobTitle = job?.Title ?? "";
            entiry.CorporateName = job?.CorporateName??"";
            entiry.CandidateName = $"{cand.FirstName} {cand.LastName}";
            entiry.CandidateEmail = cand.Email;
            entiry.CandidateMobile = cand.Mobile;
            entiry.CoverLetters = new List<CoverLetter>();
            entiry.ReviewQuestions = _appDbContext.HrReviewQuestions.Where(x => x.JobOrderID == jobOrderId).ToList();
            entiry.ReviewQuestions.ForEach(x => x.SplitSrcDataToList());
            entiry.Resumes = new List<Resume>();
            entiry.ArrangeReviewQuestionDisplayKeys();
            resumes.ForEach(x => entiry.Resumes.Add(
                new Resume
                {
                    Name = $"{x.EntityValue} ({x.EntityDesc})",
                    Url = _cdnFileService.GetCandidateResumeUrl(candidateId, x.EntityValue)
                }));
            return entiry;
        }

        public ReturnObj Submit(HrJobSendout jobSendout ,string userId)
        {
            return SaveData(jobSendout, null, userId);
        }

        //public ReturnObj Submit(HrJobSendoutDTO jobSendoutDTO, string userId)
        //{
        //    return SaveData(null, jobSendoutDTO, userId);
        //}

        private ReturnObj SaveData(HrJobSendout jobSendout, HrJobSendoutDTO jobSendoutDTO, string userId)
        {
            int jobId = jobSendout?.JobOrderID == null ? jobSendoutDTO.JobOrderID : jobSendout.JobOrderID;
            //int candId = jobSendout?.CandidateID == null ? jobSendoutDTO.Candi : hrJobSendout.CandidateID;
            var jobOrder = _appDbContext.HrJobOrders.Where(x=> x.JobOrderID == jobId).FirstOrDefault();
            if (jobOrder == null) return null;

            HrJobSendout jso = new HrJobSendout();
            jso.ID = 0;
            jso.CandidateID = jobSendout.CandidateID;
            jso.JobOrderID = jobOrder.JobOrderID;
            jso.CorporateID = jobOrder.CorporateID;
            jso.CorporateContact = jobOrder.CorporateContact;
            jso.CorporateEmail = jobOrder.CorporateContact;
            jso.IsEmailSent = false;
            jso.IsRead = false;
            jso.Sender = userId;
            jso.DateAdded = DateTime.UtcNow;
            jso.CreatedOn = DateTime.UtcNow;
            jso.Active = true;
            jso.Status = 0;
            var addedEntity = _appDbContext.HrJobSendouts.Add(jso);
            _appDbContext.Entry(jso).State = EntityState.Added;
            _appDbContext.SaveChanges();
            return new ReturnObj(true);
        }

    }
}
