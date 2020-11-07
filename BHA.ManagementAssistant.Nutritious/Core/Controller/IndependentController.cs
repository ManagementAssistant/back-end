using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller
{
    [AllowAnonymous()]
    public abstract class IndependentController : ControllerBase
    {
        public IndependentController()
        {
        }
    }
}