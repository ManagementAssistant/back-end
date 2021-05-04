using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers.Entity
{
    [Route("api/menuelement")]
    [ApiController]
    public class MenuElementController : ManagementAssistantApiController
    {
        IMenuElementService _menuElementService;
        public MenuElementController(IMenuElementService menuElementService)
        {
            this._menuElementService = menuElementService;
        }

        [HttpGet()]
        public IQueryable<MenuElement> Get()
        {
            return this._menuElementService.GetMenuElement();
        }
    }
}
