using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers
{
    [Route("company")]
    public class CompanyController : ManagementAssistantApiController
    {
        [HttpGet("list")]
        public List<Object> Get()
        {
            List<object> list = new List<object>();
            foreach (var claim in HttpContext.User.Claims)
            {
                list.Add(claim);
            }
            return list;
        }
    }
}