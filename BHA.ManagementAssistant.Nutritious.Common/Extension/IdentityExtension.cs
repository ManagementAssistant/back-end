using BHA.ManagementAssistant.Nutritious.Common.Constant;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace BHA.ManagementAssistant.Nutritious.Common.Extension
{
    public static class IdentityExtension
    {
        public static ClaimsIdentity CreateClaimsPrincipal(this IIdentity identity)
        {
            if (identity is ClaimsIdentity)
            {
                return identity as ClaimsIdentity;
            }
            return null;
        }

        public static int GetUserID(this IIdentity identity)
        {
            int userID = Numbers._zero;
            ClaimsIdentity claimsIdentity = identity.CreateClaimsPrincipal();

            string userIDValue = claimsIdentity.FindFirstValue(MAClaims.ID);
            int.TryParse(userIDValue, out userID);

            return userID;
        }

        public static int GetOrganizationID(this IIdentity identity)
        {
            int organizationID = Numbers._zero;
            ClaimsIdentity claimsIdentity = identity.CreateClaimsPrincipal();

            string organizationIDValue = claimsIdentity.FindFirstValue(MAClaims.OrganizationID);
            int.TryParse(organizationIDValue, out organizationID);

            return organizationID;
        }

        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            Claim claim = identity.Claims.FirstOrDefault(c => c.Type == claimType);
            if (claim != null)
            {
                return claim.Value;
            }
            return null;
        }
    }
}
