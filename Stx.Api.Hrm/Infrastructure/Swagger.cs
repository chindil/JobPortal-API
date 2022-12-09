using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Stx.Api.Hrm.Infrastructure
{
    public static class SwaggerServiceExtensions
    {
        //public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        //{
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1.0", new Info { Title = "Main API v1.0", Version = "v1.0" });

        //        c.AddSecurityDefinition("Bearer", new ApiKeyScheme
        //        {
        //            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        //            Name = "Authorization",
        //            In = "header",
        //            Type = "apiKey"
        //        });
        //    });

        //    return services;
        //}

        //public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI(c =>
        //    {
        //        c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");

        //        c.DocExpansion("none");
        //    });

        //    return app;
        //} 
        



    }

    //public class SwaggerTagFilter : IDocumentFilter
    //{
    //    public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
    //    {
    //        foreach (var contextApiDescription in context.ApiDescriptions)
    //        {
    //            var actionDescriptor = (ControllerActionDescriptor)contextApiDescription.ActionDescriptor;

    //            if (!actionDescriptor.ControllerTypeInfo.GetCustomAttributes<SwaggerTagAttribute>().Any() &&
    //            !actionDescriptor.MethodInfo.GetCustomAttributes<SwaggerTagAttribute>().Any())
    //            {
    //                var key = "/" + contextApiDescription.RelativePath.TrimEnd('/');
    //                swaggerDoc.paths.Remove(key);
    //            }
    //        }
    //    }
    //}

    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    //    public class SwaggerTagAttribute : Attribute
    //    {
    //    }
}
