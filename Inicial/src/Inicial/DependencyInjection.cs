using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public static class DependencyInjection
    {
        public static void AddDependencyInject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IItemRepository, ItemRepositoryDatabase>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}

