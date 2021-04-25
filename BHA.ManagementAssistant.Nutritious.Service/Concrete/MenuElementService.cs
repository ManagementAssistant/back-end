using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Core.Service.Concrete;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Service.Interface;

namespace BHA.ManagementAssistant.Nutritious.Service.Concrete
{
    public class MenuElementService : EntityService<MenuElement>, IMenuElementService
    {
        public MenuElementService(IRepository<MenuElement> repositoryMenuElement) : base(repositoryMenuElement)
        {

        }

    }
}
