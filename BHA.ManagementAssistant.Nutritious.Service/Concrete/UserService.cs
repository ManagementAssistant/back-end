using BHA.ManagementAssistant.Nutritious.Core.BaseResponse;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Repository.Interface;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repositoryUser;
        public UserService(IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public ApiResponse<IQueryable<User>> GetUsers()
        {
            ApiResponse<IQueryable<User>> response = new ApiResponse<IQueryable<User>>();
            response.Data = _repositoryUser.GetAll();
            response.isSuccess = true;

            return response;
        }
    }
}
