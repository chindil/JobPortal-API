using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace Stx.Api.Hrm.Auth
{
    //public class TokenUserInfo: ControllerBase
    //{

    //    public TokenData GetUserData()
    //    {
    //        ClaimsPrincipal principal = HttpContext.User.Claims as ClaimsPrincipal;
    //        if (null != principal)
    //        {
    //            foreach (Claim claim in principal.Claims)
    //            {
    //                Response.Write("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
    //            }

    //        }


    //        var identity = HttpContext.User.Identity as ClaimsIdentity;
    //        if (identity != null)
    //        {
    //            IEnumerable<Claim> claims = identity.Claims;
    //            // or
    //            identity.FindFirst("ClaimName").Value;

    //        }

    //        var address = User.Claims.Where('GET THE NEEDED CLAIM');

    //        var claim = ClaimsPrincipal.Claims.Where(c => c.Type == jwtClaim.ToString()).FirstOrDefault();
    //        var userId = User.GetClaim(JwtClaim.UserId);

    //        if (ClaimsPrincipal.Current?.Claims != null)
    //        {
    //            var claims =
    //               from c in ClaimsPrincipal.Current.Claims
    //               select new
    //               {
    //                   c.Type,
    //                   c.Value,
    //                   c.Issuer,
    //                   c.OriginalIssuer
    //               };
    //        }

    //        return new TokenData() { UserID = 100, UserCode = "" };
    //    }
    //}

    public class TokenData
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
    }
}
