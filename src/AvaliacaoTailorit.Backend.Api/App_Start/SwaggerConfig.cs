using System.Web.Http;
using Swashbuckle.Application;
using System.Reflection;
using System;

namespace AvaliacaoTailorit.Backend.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            string versao = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion($"v1", $"Documenta��o API Avalia��o {versao}");

                    c.IncludeXmlComments(string.Format(
                    @"{0}\bin\AvaliacaoTailorit.Backend.Api.xml",
                    AppDomain.CurrentDomain.BaseDirectory));

                    c.DescribeAllEnumsAsStrings();
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle($"Documenta��o API Avalia��o {versao}");

                    c.SupportedSubmitMethods(new string[] { });
                });
        }
    }
}
