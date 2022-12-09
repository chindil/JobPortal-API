using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Interfaces.HRM
 {
    public interface IJobOrderPreviewRepository
    {
        public HrJobOrderPreviewDTO GetRecordByID(int id, int candidateID);

        //public HrJobOrderPreview UpdateRecord(HrJobOrderPreview entry, EntryState entryState, string userId); //Submit Job 
        public string Action(CandidateJobOrderActionDto candidateJobOrderActionDto);

    }
}
