using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common.Extension
{
    public static class ServiceProviderExtension
    {
        public static T GetService<T>(this IServiceProvider serviceProvider) where T : class
        {
            T repositoryEntity = serviceProvider.GetService(typeof(T)) as T;

            return repositoryEntity;
        }
    }
}
