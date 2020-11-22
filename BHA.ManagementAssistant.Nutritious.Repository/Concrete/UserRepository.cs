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
        private IHttpContextAccessor _httpContextAccessor;
        private IServiceProvider _serviceProvider;

        public UserRepository(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            this._serviceProvider = serviceProvider;
            this._httpContextAccessor = httpContextAccessor;
        }

        private IQueryable<User> queryUser
        {
            get
            {
                _queryUser = _serviceProvider.GetService<IUserRepository>().ForJoin();

                return _queryUser;
            }
        }

        private User user
        {
            get
            {
                if (_user == null)
                {
                    int currentUserID = _httpContextAccessor.GetCurrentUserID();
                    _user = _queryUser.Where(item => item.ID == currentUserID).FirstOrDefault();

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

        public IQueryable<User> ForJoin()
        {
            return queryUser;
        }
    }
}
