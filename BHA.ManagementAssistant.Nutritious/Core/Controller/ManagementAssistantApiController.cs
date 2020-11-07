using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller
{
    [Authorize]
    public abstract class ManagementAssistantApiController : ControllerBase
    {

    }
}