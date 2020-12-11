using BHA.ManagementAssistant.Nutritious.Model.Entity;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Repository.Interface
{
    public interface IUserRepository
    {
        int GetCurrentUserID();
        User GetCurrentUser();
        IQueryable<User> ForJoin();
    }
}
