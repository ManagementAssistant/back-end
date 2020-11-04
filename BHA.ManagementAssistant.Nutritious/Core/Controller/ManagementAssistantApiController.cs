using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller
{
    [Authorize]
    public abstract class ManagementAssistantApiController : ControllerBase
    {
        public ManagementAssistantApiController()
        {
            ValidateToken();
        }

        protected virtual void ValidateToken()
        {
            System.Threading.Thread.CurrentPrincipal = new ClaimsPrincipal();
            var x = ControllerContext;
            //System.Threading.Thread.CurrentPrincipal = HttpContext.User.CreateClaimsPrincipal();
            System.Threading.Thread.CurrentPrincipal = User.CreateClaimsPrincipal();
        }
    }
}