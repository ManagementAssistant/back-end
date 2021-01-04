using BHA.ManagementAssistant.Nutritious.Core.BaseResponse;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public ApiResponse<IQueryable<Company>> Get()
        {
            return _companyService.GetCompanies();
        }

        [HttpPost("create")]
        public Company Create(Company company)
        {
            return _companyService.Create(company);
        }

        [HttpPost("update")]
        public Company Update(Company company)
        {
            return _companyService.Update(company);
        }

        [HttpPost("delete")]
        public bool Delete(Company company)
        {
            return _companyService.Delete(company);
        }
    }
}