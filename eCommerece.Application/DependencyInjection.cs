using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eCommerece.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cnfg=> cnfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
