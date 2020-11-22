using BHA.ManagementAssistant.Nutritious.Model.Entity;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Repository.Interface
{
    public interface IUserRepository
    {
        IQueryable<User> ForJoin();
        int GetCurrentUserID();
        User GetCurrentUser();
    }
}
