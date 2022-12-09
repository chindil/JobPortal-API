using Stx.Shared;
using Stx.Shared.Bps;
using Stx.Shared.Status;
using System.Collections.Generic;

namespace Stx.Api.Hrm.Interfaces.CRM
{
    public interface IClientRepository
    {
        public List<Contact> GetAllRecords();

        public Contact GetRecordByID(int docNum);

        public Contact UpdateRecord(Contact record, EntryState st, string userId);

        public bool DeleteRecord(int docnum, string userId);
       
    }
}
