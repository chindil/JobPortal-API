using Stx.Shared.Models.CRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;
using System.Collections.Generic;

namespace Stx.Api.Hrm.Interfaces.CRM
{
    public interface ICorporatePublicRepository
    {
        public CorporatePublicDTO GetRecordByID(int id, int candidateID);
        public List<CorporatePublicDTO> Search(string keyword, string location, int candidateID);
        public List<CorporatePublicDTO> Search(HrJobSearchParmDTO searchParmDTO);

        //public CorporatePublicDTO UpdateRecord(CorporatePublicDTO entry, EntryState entryState, string userId); //Submit Job 

    }
}
