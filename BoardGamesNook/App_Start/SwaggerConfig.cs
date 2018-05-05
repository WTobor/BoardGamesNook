using System.Web.Http;
using WebActivatorEx;
using BoardGamesNook;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BoardGamesNook
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "BoardGamesNook");
                        //c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi();
        }

        //private static string GetXmlCommentsPath()
        //{
        //    return $"{AppDomain.CurrentDomain.BaseDirectory}bin\\BoardGamesNook.xml";
        //}
    }
}
