using Microsoft.Extensions.DependencyInjection;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Application.Common.Interfaces.Services;
using Replica.Infrastructure.Repositories;
using Replica.Infrastructure.Services;

namespace Replica.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IJwtParserService, JwtParserService>();

            return services;
        }
    }
}
