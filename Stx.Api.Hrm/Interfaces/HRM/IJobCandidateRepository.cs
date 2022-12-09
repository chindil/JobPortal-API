using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Interfaces.HRM
 {
    public interface IJobCandidateRepository
    {

        public HrJobCandidate GetRecordByID(int id);

        //public HrJobCandidate GetRecordByCD(string code);
        /// <summary>
        /// Get Candidate public data based on the candidate-stage & Job order id
        /// </summary>
        /// <param name="candidateStage">Candidate stage (sourced, applied, interview) </param>
        /// <param name="jobOrderId">Job oder id</param>
        /// <returns></returns>
        public List<HrJobCandidateListDTO> GetRecordListByStage(string candidateStage, int jobOrderId);

        public List<HrJobCandidateListDTO> Search(HrJobCandidateParmDTO searchParms);

        public HrJobCandidate UpdateRecord(HrJobCandidate entry, EntryState entryState, string userId);

        public bool? DeleteRecord(int id, string userId);

    }
}
