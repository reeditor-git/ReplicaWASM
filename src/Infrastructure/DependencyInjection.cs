using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Replica.Application.Common.Interfaces.Authentication;
using Replica.Application.Common.Interfaces.Helpers;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Infrastructure.Authentication;
using Replica.Infrastructure.Context;
using Replica.Infrastructure.Helpers;
using Replica.Infrastructure.Repositories;
using System.Text;

namespace Replica.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReplicaDbContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("ReplicaDb"),
            options => options.MigrationsAssembly("Replica.Infrastructure")));


            var jwtSettings = new JwtSettings();

            configuration.Bind("JwtSettings", jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddSingleton<IJwtTokenService, JwtTokenService>();

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = signingKey,
                    RoleClaimType = JwtClaimTypes.Role,
                    ClockSkew = TimeSpan.Zero
                });

            services.AddScoped<ICryptoService, CryptoService>();
            services.AddScoped<IJwtParser, JwtParser>();
            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IConfirmationStatusRepository, ConfirmationStatusRepository>();
            services.AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>();
            services.AddScoped<IProductCountRepository, ProductCountRepository>();
            services.AddScoped<IPaymentStatusRepository, PaymentStatusRepository>();

            return services;
        }
    }
}
