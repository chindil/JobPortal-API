using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Shared.Models.CRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Models.Parm;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stx.Api.Hrm.Repos.CRM
{
    public class CorporatePublicRepository : ICorporatePublicRepository
    {
        private readonly StxDbContext _appDbContext;

        public CorporatePublicRepository(StxDbContext appDbContext, ILogger<CorporatePublicRepository> logger)
        {
            _appDbContext = appDbContext;
        }

        public CorporatePublicDTO GetRecordByID(int id, int candidateID)
		{
            string qry = $"EXEC [CRMCorporatePreview] @CorporateID={id}, @UserName={candidateID}";
            var entry = _appDbContext.Set<CorporatePublicDTO>().FromSqlRaw(qry).AsEnumerable().FirstOrDefault();
            return entry;
        }

        public List<CorporatePublicDTO> Search(HrJobSearchParmDTO searchParmDTO)
        {
            return Search(searchParmDTO.Keyword, searchParmDTO.Location, searchParmDTO.CandidateID);

        }

        public List<CorporatePublicDTO> Search(string keyword, string location, int candidateID)
        {
            string qry = $"EXEC [CRMCorporateSearch] @Keyword='{keyword}', @Location='{location}', @CandidateID={candidateID}";
            var entry = _appDbContext.Set<CorporatePublicDTO>().FromSqlRaw(qry).ToList();
            return entry;
        }
	}
}
