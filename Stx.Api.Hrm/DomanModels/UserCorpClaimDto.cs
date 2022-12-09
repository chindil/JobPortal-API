using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.DomanModels
{
    public class UserCorpClaimDto
    {
        public UserCorpClaimDto(int userId, int corpId)
        {
            this.UserID = userId;
            this.CorpID = corpId;
        }
        public int UserID { get; set; }
        public int CorpID { get; set; }
    }
}
