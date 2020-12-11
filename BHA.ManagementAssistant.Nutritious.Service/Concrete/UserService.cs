using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Core.Service.Concrete;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Concrete
{
    public class UserService : EntityService<User>, IUserService
    {
        public UserService(IRepository<User> repositoryUser): base(repositoryUser)
        {

        }

        public IQueryable<User> GetUser()
        {
            return this.Repository.GetAll();
        }
    }
}
