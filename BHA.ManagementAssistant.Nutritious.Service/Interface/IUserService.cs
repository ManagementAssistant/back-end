using BHA.ManagementAssistant.Nutritious.Core.Service.Interface;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Interface
{
    public interface IUserService : IEntityService<User>
    {
        IQueryable<User> GetUser();
    }
}
