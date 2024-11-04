using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Stock.API.Configurations.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            var startupAssembly = Assembly.GetEntryAssembly();

            services.AddSwaggerExamplesFromAssemblyOf<Program>();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    var assemblyDetails = startupAssembly?.GetCustomAttribute<AssemblyProductAttribute>();

                    c.SwaggerDoc(description.GroupName, new OpenApiInfo()
                    {
                        Title = $"{assemblyDetails?.Product} {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = "Stock API - Description"
                    });
                }

                c.IncludeXmlComments(xmlPath);
                c.ExampleFilters();
            });
        }

        public static void UseSwaggerPage(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                foreach (var description in provider.ApiVersionDescriptions.Select(s => s.GroupName))
                {
                    sw.SwaggerEndpoint($"./swagger/{description}/swagger.json", $"Stock.Api - {description.ToUpperInvariant()}");
                }

                sw.RoutePrefix = string.Empty;
            });
        }
    }
}
