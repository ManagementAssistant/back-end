using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Core
{
    public interface IUserNutritious
    {
        int GetCurrentUserID();
        string GetCurrentUserName();
    }
}
