using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Replica.Server.DependencyInjection
{
    public static class CustomSwagger
    {
        public static IServiceCollection AddCustomSwagger (this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Replica API",
                    Description = "API of the lounge bar control system",
                    Contact = new OpenApiContact
                    {
                        Name = "Roman Tymoshchuk",
                        Email = "roman.tymoshchuk@oa.edu.ua"
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.\n\nExample: 'Bearer {token}'",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return services;
        }
    }
}
