using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Infrastructure
{
    public class DatabaseMigration
    {
        //private readonly StxDbContext _dataContext;
        //private static readonly ILogger<DatabaseMigration> _logger;

        //public DatabaseMigration (StxDbContext dataContext, ILogger<DatabaseMigration> logger)
        //{
        //    _dataContext = dataContext;
        //    _logger = logger;
        //}

        public static bool RunDatabaseMigration(StxDbContext dataContext, ILoggerFactory loggerFactory)
        {
            try
            {
                dataContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DatabaseMigration>();
                logger.LogError("Database Migration: " + ex.Message);
                return false;
            }
            return false;
        }
    }
}
