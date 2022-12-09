using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stx.Shared.Api.Helpers
{
    public class TokenUserInfo
    {
        public static TokenData GetUserData()
        {
            if (ClaimsPrincipal.Current?.Claims != null)
            {
                var claims =
                   from c in ClaimsPrincipal.Current.Claims
                   select new
                   {
                       c.Type,
                       c.Value,
                       c.Issuer,
                       c.OriginalIssuer
                   };
            }

            return new TokenData() { UserID = 100, UserCode = "" };
        }
    }

    public class TokenData
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
    }
}
