using BHA.ManagementAssistant.Nutritious.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Repository.Interface
{
    public interface IUserRepository
    {
        int GetCurrentUserID();
        User GetCurrentUser();
    }
}
