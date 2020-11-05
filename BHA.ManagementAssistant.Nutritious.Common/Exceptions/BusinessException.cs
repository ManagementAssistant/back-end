using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common.Exceptions
{
    public class BusinessException: ManagementAssistantException
    {
        public BusinessException(string message): base(message)
        {

        }
    }
}
