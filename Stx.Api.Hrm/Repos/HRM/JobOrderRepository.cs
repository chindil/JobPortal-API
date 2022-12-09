using Stx.Shared.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared;
using Stx.Shared.Common;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;
using Stx.Api.Hrm.DomanModels;

namespace Stx.Api.Hrm.Repos.HRM
{
    public class JobOrderRepository : IJobOrderRepository
    {
        private readonly StxDbContext _appDbContext;

        public JobOrderRepository(StxDbContext appDbContext, ILogger<JobOrderRepository> logger)
        {
            _appDbContext = appDbContext;
        }

		public List<HrJobOrder> GetAllRecords()
		{
            return _appDbContext.HrJobOrders.OrderByDescending(x=> x.JobOrderID).Take(50).ToList();
        }

        public HrJobOrder GetRecordByID(int jobOrderId)
		{
            return _appDbContext.HrJobOrders.Where(c => c.JobOrderID == jobOrderId).FirstOrDefault();
        }

        public HrJobSummaryDTO GetJobSummaryByID(int jobOrderId)
		{
            return GetCorporateJobList(null, jobOrderId).FirstOrDefault();
        }

        public List<HrJobSummaryDTO> GetCorporateJobList(int corpId)
        {
            return GetCorporateJobList(corpId, null);
        }
        public List<HrJobSummaryMinDTO> GetCorporateJobListMin(int corpId)
        {
            List<HrJobSummaryMinDTO> list = new List<HrJobSummaryMinDTO>();
            var jobs = GetCorporateJobList(corpId, null);
            jobs.ForEach(j => list.Add(new HrJobSummaryMinDTO
            {
                CorporateID = j.CorporateID,
                JobOrderID = j.JobOrderID,
                Title = j.Title,
                Country = j.Country,
                Location = j.Location,
                Description = j.Description,
                EmploymentType = j.EmploymentType,
                JobIndustry = j.JobIndustry,
                JobSpecialty = j.JobSpecialty,
                DateStart = j.DateStart,
                DateEnd = j.DateEnd,
                Status = j.Status,
            }));
            return list;
        }

        public List<HrJobSummaryDTO> GetCorporateJobList(int? corpId, int? jobId)
		{
            string qry = $"EXEC [HRMCorporateJobList] @CorporateID, @JobOrderID";

            object[] parm =
            {
                new SqlParameter("@CorporateID", corpId ?? (object)DBNull.Value),
                new SqlParameter("@JobOrderID", jobId ?? (object)DBNull.Value),
            };
            return _appDbContext.Set<HrJobSummaryDTO>().FromSqlRaw(qry, parm).AsEnumerable().ToList();
        }

        public HrJobOrder UpdateRecord(HrJobOrder entry, UserCorpClaimDto userCorpClaim)
		{
            if (entry.JobOrderID <= 0)
            {
                var addedEntity = _appDbContext.HrJobOrders.Add(entry);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            else
			{
                _appDbContext.HrJobOrders.Add(entry);
                _appDbContext.Entry(entry).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                var entryToUpdate = _appDbContext.HrJobOrders.FirstOrDefault(e => e.JobOrderID == entry.JobOrderID);

                if (entryToUpdate == null)
                {
                    return null;
                }
                return entryToUpdate;
            }
        }

        public bool? UpdateQuery(int id, List<ParmStr> values, string userId)
        {
            var entryToUpdate = _appDbContext.HrJobOrders.FirstOrDefault(e => e.JobOrderID == id);
            if (entryToUpdate == null) return null;

            foreach (var parm in values)
            {
                if (parm.Value.InIgnoreCase("IsReqAutoRejectEmail"))
                    entryToUpdate.IsReqAutoRejectEmail = Conv.ToBool(parm.Text);
                else if (parm.Value.InIgnoreCase("AutoRejectEmailTemplate"))
                    entryToUpdate.AutoRejectEmailTemplate = parm.Text;
            }
            entryToUpdate.DateLastModified = DateTime.UtcNow;

            _appDbContext.HrJobOrders.Add(entryToUpdate);
            _appDbContext.Entry(entryToUpdate).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return true;
        }

        public bool? DeleteRecord(int id, string userId)
		{
            var entryToDelete = _appDbContext.HrJobOrders.FirstOrDefault(e => e.JobOrderID == id);
            if (entryToDelete == null) return false;

            _appDbContext.HrJobOrders.Remove(entryToDelete);
            _appDbContext.SaveChanges();
            return true;
        }

        public List<HrReviewQuestion> GetReviewQuestions(int jobId)
        {
            return _appDbContext.HrReviewQuestions.Where(c => c.JobOrderID == jobId).ToList();
        } 
        

        public List<HrReviewQuestion> UpdateReviewQuestions(List<HrReviewQuestion> entries, string userId)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            {
                try
                {
                    foreach (var item in entries)
                    {
                        item.DateLastModified = DateTime.UtcNow;
                        item.UserModified = userId;

                        _appDbContext.HrReviewQuestions.Add(item);
                        _appDbContext.Entry(item).State = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    }
                    _appDbContext.SaveChanges();
                    transaction.Commit();

                    return _appDbContext.HrReviewQuestions.Where(c => c.JobOrderID == entries.FirstOrDefault().JobOrderID).ToList();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }
        public bool DeleteReviewQuestion(int jobOrderId, int Id)
        {
            var rec = _appDbContext.HrReviewQuestions.Where(x => x.JobOrderID == jobOrderId && x.ID == Id).AsNoTracking().FirstOrDefault();

            if (rec != null)
            {
                _appDbContext.HrReviewQuestions.Remove(rec);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
