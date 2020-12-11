using BHA.ManagementAssistant.Nutritious.Common.Extension;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        private User _user;
        private IQueryable<User> _queryUser;
        private IRepository<User> _repositoryUser;
        private IHttpContextAccessor _httpContextAccessor;
        private IServiceProvider _serviceProvider;

        public UserRepository(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            this._serviceProvider = serviceProvider;
            this._httpContextAccessor = httpContextAccessor;
        }

        private IRepository<User> repositoryUser
        {
            get
            {
                if (_repositoryUser == null)
                {
                    _repositoryUser = _serviceProvider.GetService<IRepository<User>>();
                }

                return _repositoryUser;
            }
        }

        private IQueryable<User> queryUser
        {
            get
            {
                if (_queryUser == null)
                {
                    _queryUser = repositoryUser.ForJoin();
                }

                return _queryUser;
            }
        }

        private User user
        {
            get
            {
                if (_user == null)
                {
                    _user = repositoryUser.GetByID(this.GetCurrentUserID());
                }

                if (_user == null)
                {
                    throw new Exception("user.id.invalid");
                }

                return _user;
            }
        }

        public IQueryable<User> ForJoin()
        {
            return queryUser;
        }

        public User GetCurrentUser()
        {
            return user;
        }

        public int GetCurrentUserID()
        {
            return _httpContextAccessor.GetCurrentUserID();
        }
    }
}
