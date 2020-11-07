using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Context;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Repository.Interface;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using System;
using BHA.ManagementAssistant.Nutritious.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Common.Exceptions;

namespace BHA.ManagementAssistant.Nutritious.Model.Repository.Concrete
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private User _user;
        public UserRepository(ManagementAssistantContext context) : base(context) { }

        private User user
        {
            get
            {
                if (_user == null)
                {
                    _user = this.GetByID(this.GetCurrentUserID());

                    if (_user == null)
                    {
                        throw new TechnicalException("user.id.invalid");
                    }
                }

                return _user;
            }
        }

        public int GetCurrentUserID()
        {
            return System.Threading.Thread.CurrentPrincipal.Identity.GetUserID();
        }

        public string GetCurrentUserName()
        {
            return user.Name;
        }
    }
}
