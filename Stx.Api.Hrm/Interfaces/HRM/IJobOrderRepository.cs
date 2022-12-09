using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Api.Hrm.DomanModels;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Interfaces.HRM
 {
    public interface IJobOrderRepository
    {
        public HrJobOrder GetRecordByID(int jobOrderId);
        public HrJobSummaryDTO GetJobSummaryByID(int jobOrderId);

        public List<HrJobSummaryDTO> GetCorporateJobList(int corpId);
        public List<HrJobSummaryMinDTO> GetCorporateJobListMin(int corpId);

        public List<HrReviewQuestion> GetReviewQuestions(int jobId);
        public List<HrReviewQuestion> UpdateReviewQuestions(List<HrReviewQuestion> reviewQuestions, string userId);
        public bool DeleteReviewQuestion(int jobOrderId, int Id);


        public HrJobOrder UpdateRecord(HrJobOrder entry, UserCorpClaimDto userCorpClaim);
        public bool? UpdateQuery(int id, List<ParmStr> values, string userId);
        public bool? DeleteRecord(int id, string userId);
    }
}
