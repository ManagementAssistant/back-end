using BHA.ManagementAssistant.Nutritious.Common.MiddleWare;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common.Extension
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApplicationBuilderMiddleWare>();
        }
    }
}
