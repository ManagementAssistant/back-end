using BHA.ManagementAssistant.Nutritious.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common.Extension
{
    public static class PrincipalExtension
    {
        public static ClaimsPrincipal CreateClaimsPrincipal(this IPrincipal principal)
        {
            if (principal is ClaimsPrincipal)
            {
                return principal as ClaimsPrincipal;
            }
            return null;
        }

        public static int GetUserID(this IPrincipal principal)
        {
            int userID = Numbers._zero;
            ClaimsPrincipal claimsPrincipal = principal.CreateClaimsPrincipal();

            string userIDValue = claimsPrincipal.FindFirstValue("id");
            int.TryParse(userIDValue, out userID);

            return userID;
        }

        public static string FindFirstValue(this ClaimsPrincipal principal, string claimType)
        {
            Claim claim = principal.Claims.FirstOrDefault(c => c.Type == claimType);
            if (claim != null)
            {
                return claim.Value;
            }
            return null;
        }
    }
}
