using eCommerece.Application.Interfaces;
using eCommerece.Infrastructure.Options;
using eCommerece.Infrastructure.Services.DBConnectionService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace eCommerece.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionOptions>(configuration.GetSection("ConnectionString"));
            services.Configure<AuthenticationOptions>(configuration.GetSection("Jwt"));
            services.AddSingleton<IDBConnectionFactory,DBConnectionFactory>();
            var jwtOptions = configuration.GetSection("Jwt").Get<AuthenticationOptions>();
            if(jwtOptions is null)
            {
                throw new Exception("Jwt options are not configured properly.");
            }
            services.AddSingleton<IPasswordHasher, Services.PasswordHasher.PasswordHasher>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer((op) =>
            {
                op.RequireHttpsMetadata = false;
                op.SaveToken = true;
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOptions.Key)),
                };
            });
            return services;
        }
    }
}
