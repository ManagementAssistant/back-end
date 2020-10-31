using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Model.Model.Baseless.AuthenticationOperation
{
    public class AuthenticationViewModel
    {
        public bool isLogin { get; set; }
        public string Token { get; set; }
        public DateTime Expire { get; set; }
    }
}
