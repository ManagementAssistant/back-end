using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Repository.Interface;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController : ManagementAssistantApiController
    {
        private IUserService _userService;
        private ICompanyService _companyService;
        public CompanyController(IUserService userService, ICompanyService companyService)
        {
            _userService = userService;
            _companyService = companyService;
        }

        [HttpGet("list")]
        public Object Get()
        {
            return _companyService.GetCompanies();
        }
    }
}