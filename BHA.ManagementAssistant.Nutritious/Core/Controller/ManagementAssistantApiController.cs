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
        
    }
}