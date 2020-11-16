using BHA.ManagementAssistant.Nutritious.Model.Entity;

namespace BHA.ManagementAssistant.Nutritious.Repository.Interface
{
    public interface IUserRepository
    {
        int GetCurrentUserID();
        User GetCurrentUser();
    }
}
