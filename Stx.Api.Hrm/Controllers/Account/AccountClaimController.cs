using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.Account;
using Stx.Shared.Models.Account;

namespace Stx.Api.Hrm.Controllers.Account
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiExplorerSettings(IgnoreApi = Shared.Api.InternalConfig.SwaggerDocs.IsHideAccountApi)]
    public class AccountClaimController : ControllerBase
    {
        private readonly IAccountClaimRepository _IRepository;

        public AccountClaimController(IAccountClaimRepository iRepository)
        {
            _IRepository = iRepository;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody] List<SigninUserClaim> value)
        {
            var result = await _IRepository.UpdateRecord(value);
            if (result == null || result == false)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"The operation couldn’t be completed.", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };
                return NotFound(response);
            }

            return Ok();
        }
    }
}
