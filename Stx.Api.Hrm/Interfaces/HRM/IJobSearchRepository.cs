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
    public interface IJobSearchRepository
    {
        //public List<HrJobOrderSearch> Search (string keyword, string location, string jobindustry, int candidateid);
        public List<HrJobOrderSearch> Search (HrJobSearchParmDTO hrJobSearchParm);
    }
}
