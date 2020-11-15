using BHA.ManagementAssistant.Nutritious.Service.Interface;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers
{
    [ApiController]
    [Route("api/company")]
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