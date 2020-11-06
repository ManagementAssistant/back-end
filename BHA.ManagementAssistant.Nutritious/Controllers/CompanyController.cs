using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using BHA.ManagementAssistant.Nutritious.Model.Repository.Interface;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController : ManagementAssistantApiController
    {
        IUserRepository _repo;
        public CompanyController(IUserRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("list")]
        public Object Get()
        {
            return _repo.GetCurrentUserID();
        }
    }
}