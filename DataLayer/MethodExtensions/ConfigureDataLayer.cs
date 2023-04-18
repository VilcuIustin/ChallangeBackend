using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.MethodExtensions
{
    public static class ConfigureDataLayer
    {
        public static void AddDataLayer(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
