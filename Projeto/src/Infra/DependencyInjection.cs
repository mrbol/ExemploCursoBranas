using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Infra.Persistence;

namespace Infra
{
    public static class DependencyInjection
    {
        public static void AddPersistenceInject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IDapperAdapter, DapperAdapter>();
            services.AddScoped<IItemRepository, ItemRepositoryDatabase>();
        }
    }
}
