using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller
{
    [Authorize]
    public abstract class ManagementAssistantApiController : ControllerBase
    {
        public ManagementAssistantApiController()
        {

        }
    }
}