using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Repository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Model.Repository.Concrete
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ManagementAssistantContext context) : base(context) { }
    }
}
