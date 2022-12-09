using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Models.DTO.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;

namespace Stx.Api.Hrm.Interfaces.HRM
 {
    public interface IJobSendoutRepository
    {
        public ReturnObj Submit (HrJobSendout jobSendout, string userId);
        public HrJobSendoutDTO GetJobSubmitData (int jobOrderId, int candidateId);
    }
}
