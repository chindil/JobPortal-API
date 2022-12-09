using Stx.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Stx.Api.Hrm.Interfaces;

namespace Stx.Api.Hrm.Repos
{
	internal class CommonDataRepository : ICommonDataRepository
    {
        private StxDbContext context;
        public CommonDataRepository(StxDbContext stxContext)
        {
            this.context = stxContext;
        }

        public DataSet GetDataset(string script)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(context.Database.GetDbConnection());
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = context.Database.GetDbConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = script;
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
            throw new Exception("Data execution failed.");
        }

        public DataTable GetDataTable(string script)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(context.Database.GetDbConnection());
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = context.Database.GetDbConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = script;
                return GetDataTable(cmd);
            }

            throw new Exception("Data execution failed.");
        }

        public DataTable GetDataTable(DbCommand command)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(context.Database.GetDbConnection());
            command.Connection = context.Database.GetDbConnection();
            using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
            {
                
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }

            throw new Exception("Data execution failed.");
        }

        //public static DataTable GetDatatable(string connstring, DbCommand Cmd)
        //{
        //    //using (SqlConnection cConn = new SqlConnection(connstring))
        //    //{
        //    //    cConn.Open();
        //    //    Cmd.Connection = cConn;
        //    //    SqlDataAdapter adp = new SqlDataAdapter(Cmd);
        //    //    DataTable dtret = new DataTable();
        //    //    adp.Fill(dtret);
        //    //    Cmd.Dispose();
        //    //    return dtret;
        //    //}
        //    //temp
        //    return null;
        //}

    }
}
