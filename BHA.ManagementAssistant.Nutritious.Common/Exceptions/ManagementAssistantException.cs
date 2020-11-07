using System;

namespace BHA.ManagementAssistant.Nutritious.Common.Exceptions
{
    public abstract class ManagementAssistantException : Exception
    {
        public ManagementAssistantException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public ManagementAssistantException(string message) : base(message)
        {

        }
    }
}
