using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesOrderApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderApp.Core.StartupExtensions
{
    public static class PersistenceStartup
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalesOrderAppContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), options =>
                {
                    options.MigrationsAssembly("SalesOrderApp.Persistence");
                });
            });
        }
    }
}
