using BHA.ManagementAssistant.Nutritious.Model.Repository.Interface;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController : ManagementAssistantApiController
    {
        private IUserService _userService;
        public CompanyController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("list")]
        public Object Get()
        {
            return _userService.GetUsers();
        }
    }
}