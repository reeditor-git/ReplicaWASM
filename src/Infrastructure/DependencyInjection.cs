using Microsoft.Extensions.DependencyInjection;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Infrastructure.Repositories;
using System.Reflection;

namespace Replica.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
