using CleanArqMvc.Application.Interfaces;
using CleanArqMvc.Infrastructure.Common;
using CleanArqMvc.Infrastructure.Repositories;
using InvestControl.Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArqMvc.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDateTime, SystemDateTime>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            AddMySql(services, configuration);
            
            return services;
        }

        private static void AddMySql(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse(configuration.GetConnectionString("Version")), builder =>
                {
                    builder.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName);
                }));
        }
    }
}
