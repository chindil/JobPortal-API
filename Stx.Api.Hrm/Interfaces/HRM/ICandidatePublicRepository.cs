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
    public interface ICandidatePublicRepository
    {
        //public List<HrCandidatePublicDTO> GetAllRecords();

        public HrCandidatePublicDTO GetRecordByID(int candidateId);
        public HrCandidatePublicDTO GetRecordByID(string candidateSource, int candidateId);
        public HrCandidatePublicDTO GetRecordByID(string candidateSource, int candidateId, int? jobOrderId);
        public HrCandidatePublicDTO GetRecordByCD(string code);

        public List<HrCandidatePublicDTO> Search(HrCandidateParmDTO searchParms);

        //public HrCorporateCandidate ImportCorporateCandidate(HrCorporateCandidate entry, string userId);

    }
}
