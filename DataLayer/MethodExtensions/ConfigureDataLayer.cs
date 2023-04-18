using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.MethodExtensions
{
    public static class ConfigureDataLayer
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            var dbSeeder = new DatabaseInit(new UnitOfWork(configuration));
            dbSeeder.CreateTablesAsync()
                .GetAwaiter()
                .GetResult();
            new DatabaseInit(new UnitOfWork(configuration)).CreateStoredProceduresAsync()
                .GetAwaiter()
                .GetResult();

        }
    }
}
