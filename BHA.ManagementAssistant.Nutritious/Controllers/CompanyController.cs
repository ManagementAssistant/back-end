using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using BHA.ManagementAssistant.Nutritious.Common.Extension;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers
{
    [Route("company")]
    public class CompanyController : ManagementAssistantApiController
    {
        [HttpGet("list")]
        public Object Get()
        {
            //return HttpContext.User.GetUserID();
            return System.Threading.Thread.CurrentPrincipal.GetUserID();
        }
    }
}