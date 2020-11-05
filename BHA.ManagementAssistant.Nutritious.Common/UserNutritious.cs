using BHA.ManagementAssistant.Nutritious.Common.Exceptions;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using BHA.ManagementAssistant.Nutritious.Core;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Repository.Interface;
using System;

namespace BHA.ManagementAssistant.Nutritious.Common
{
    public class UserNutritious : IUserNutritious
    {
        private IUserRepository _repositoryUser;
        private User _user;
        public UserNutritious(IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        private User user
        {
            get
            {
                if (_user == null)
                {
                    _user = _repositoryUser.GetByID(this.GetCurrentUserID());

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
