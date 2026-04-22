using eCommerece.Application.Interfaces;
using eCommerece.Infrastructure.Options;
using eCommerece.Infrastructure.Services.DBConnectionService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerece.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionOptions>(configuration.GetSection("ConnectionString"));
            services.AddSingleton<IDBConnectionFactory,DBConnectionFactory>();
            services.AddSingleton<IPasswordHasher, Services.PasswordHasher.PasswordHasher>();
            return services;
        }
    }
}
