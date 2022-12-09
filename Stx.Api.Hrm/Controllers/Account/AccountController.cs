
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.Account;
using Stx.Api.Hrm.Repos;
using Stx.Shared.Models.Account;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.Controllers.Account
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = Shared.Api.InternalConfig.SwaggerDocs.IsHideAccountApi)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _IRepository;

        public AccountController(IAccountRepository iRepository)
        {
            _IRepository = iRepository;
        }

        /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody] SigninUser value)
        {
            var entryToDelete = await _IRepository.RegisterUser(value);
            if (entryToDelete == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent($"The operation couldn’t be completed.", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.Unauthorized
                };
                return Unauthorized(response);
            }

            return Ok(value.Email);
        }


    }
}