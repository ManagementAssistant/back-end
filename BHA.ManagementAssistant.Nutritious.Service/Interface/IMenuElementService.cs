using BHA.ManagementAssistant.Nutritious.Core.Service.Interface;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Interface
{
    public interface IMenuElementService : IEntityService<MenuElement>
    {
        IQueryable<MenuElement> GetMenuElement();
    }
}
