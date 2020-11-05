using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common.Exceptions
{
    public class TechnicalException: ManagementAssistantException
    {
        public TechnicalException(string message): base(message)
        {

        }
    }
}
