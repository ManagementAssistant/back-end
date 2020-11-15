using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using Microsoft.AspNetCore.Http;
using System;

namespace BHA.ManagementAssistant.Nutritious.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        private User _user;
        private IRepository<User> _repositoryUser;
        private IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IRepository<User> repositoryUser, IHttpContextAccessor httpContextAccessor)
        {
            this._repositoryUser = repositoryUser;
            this._httpContextAccessor = httpContextAccessor;
        }

        private User user
        {
            get
            {
                if (_user == null)
                {
                    int currentUserID = _httpContextAccessor.GetCurrentUserID();
                    _user = _repositoryUser.GetByID(currentUserID);

                    if (_user == null)
                    {
                        throw new Exception("user.id.invalid");
                    }
                }

                return _user;
            }
        }

        public User GetCurrentUser()
        {
            return user;
        }

        public int GetCurrentUserID()
        {
            return user.ID;
        }

    }
}
