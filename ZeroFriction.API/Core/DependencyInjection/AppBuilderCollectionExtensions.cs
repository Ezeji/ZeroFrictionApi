using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroFriction.API.Core.DependencyInjection
{
    public static class AppBuilderCollectionExtensions
    {
        public static void UseSwaggerServices(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zero Friction API - v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
