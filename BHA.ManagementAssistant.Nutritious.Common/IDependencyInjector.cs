using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common
{
    public interface IDependencyInjector
    {
        T GetService<T>();
    }
}
