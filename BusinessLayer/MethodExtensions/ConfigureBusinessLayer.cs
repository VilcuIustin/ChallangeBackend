using BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MethodExtensions
{
    public static class ConfigureBusinessLayer
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductRewardService, ProductRewardService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IEmployeesSalesService, EmployeesSalesService>();
            services.AddScoped<IRemunerationService, RemunerationService>();
        }
    }
}
