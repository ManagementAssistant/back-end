using BHA.ManagementAssistant.Nutritious.Common.Constant;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BHA.ManagementAssistant.Nutritious.Common.Extension
{
    public static class HttpContextAccessorExtension
    {
        public static int GetCurrentUserID(this IHttpContextAccessor httpContextAccessor)
        {
            int userID = Numbers._zero;

            string userIDValue = httpContextAccessor.FindFirstValue(MAClaims.ID);

            int.TryParse(userIDValue, out userID);

            return userID;
        }

        public static int GetCurrentOrganizationID(this IHttpContextAccessor httpContextAccessor)
        {
            int organizationID = Numbers._zero;

            string organizationIDValue = httpContextAccessor.FindFirstValue(MAClaims.OrganizationID);

            int.TryParse(organizationIDValue, out organizationID);

            return organizationID;
        }

        public static string FindFirstValue(this IHttpContextAccessor httpContextAccessor, string claims)
        {
            string value = "0";
            Claim claim = httpContextAccessor.HttpContext.User.FindFirst(claims);
            if (claim != null)
            {
                value = claim.Value;
            }
            return value;
        }
    }
}
