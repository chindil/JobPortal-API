using Stx.Api.Hrm.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Stx.Api.Hrm.Interfaces
{
    public interface ICommonDataRepository
    {
        //public int GetNextDocNumber(short pageUid);
        DataSet GetDataset(string script);
        DataTable GetDataTable(string script);
        DataTable GetDataTable(DbCommand command);
    }
}
