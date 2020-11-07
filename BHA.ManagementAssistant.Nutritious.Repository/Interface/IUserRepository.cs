using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Entity;

namespace BHA.ManagementAssistant.Nutritious.Model.Repository.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        int GetCurrentUserID();
        string GetCurrentUserName();
    }
}
