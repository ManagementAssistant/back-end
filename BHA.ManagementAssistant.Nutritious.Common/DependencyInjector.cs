using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common
{
    public class DependencyInjector : IDependencyInjector
    {
        private readonly IServiceCollection _serviceDescriptors;
        public DependencyInjector(IServiceCollection serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }
        public T GetService<T>()
        {
            ServiceProvider services = _serviceDescriptors.BuildServiceProvider();

            return services.GetService<T>();
        }
    }
}
