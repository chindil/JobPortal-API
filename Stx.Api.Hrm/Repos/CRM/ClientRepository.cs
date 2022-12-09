using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Shared.Bps;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stx.Api.Hrm.Repos.CRM
{
    public class ClientRepository : IClientRepository
    {

        private readonly StxDbContext context;
        public ClientRepository(StxDbContext context)
        {
            this.context = context;
        }

        public bool DeleteRecord(int docnum, string userId)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAllRecords()
        {
            return context.Contacts.ToList();
        }

        public Contact GetRecordByID(int docNum)
        {
            throw new NotImplementedException();
        }

        public Contact UpdateRecord(Contact record, EntryState st, string userId)
        {
            context.Contacts.Add(record);
            context.SaveChanges();
            return context.Contacts.Where(x => x.ContactID == record.ContactID).FirstOrDefault();
        }
    }
}
