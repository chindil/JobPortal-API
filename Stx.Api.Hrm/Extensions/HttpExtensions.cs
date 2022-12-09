using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Stx.Api.Hrm.DomanModels;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared;
using Stx.Shared.Api.Helpers;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;

public static class HttpExtensions
{
    public static string GetClaim(this HttpContext httpContext, string claimName = null)
    {
        var identity = httpContext.User.Identity as ClaimsIdentity;

        //var ddd = "";
        //foreach (var claim in identity.Claims)
        //{
        //    ddd += "CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + Environment.NewLine;
        //}
        return identity.Claims.Where(x => x.Type == claimName).FirstOrDefault().Value;
    }

    public static int GetClaimUserID(this HttpContext httpContext)
    {
        var identity = httpContext.User.Identity as ClaimsIdentity;
        //Todo: Test only remove below line
        return 1;

        return Conv.TryInt(identity.Claims.Where(x => x.Type == "usrid").FirstOrDefault()?.Value);
    }

    public static int GetClaimCorporateID(this HttpContext httpContext)
    {
        var identity = httpContext.User.Identity as ClaimsIdentity;
        //Todo: Test only remove below line
        return 1;

        return Conv.TryInt(identity.Claims.Where(x => x.Type == "corpid").FirstOrDefault()?.Value);
    }

    public static UserCorpClaimDto GetClaimUserCorporateID(this HttpContext httpContext)
    {
        var identity = httpContext.User.Identity as ClaimsIdentity;
        return new UserCorpClaimDto(GetClaimUserID(httpContext), GetClaimCorporateID(httpContext));
    }
}
