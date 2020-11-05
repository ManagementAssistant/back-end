using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BHA.ManagementAssistant.Nutritious.Common.MiddleWare
{
    public class ApplicationBuilderMiddleWare
    {
        private readonly RequestDelegate _next;

        public ApplicationBuilderMiddleWare(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            System.Threading.Thread.CurrentPrincipal = context.User;
            await _next(context);
        }
    }
}
