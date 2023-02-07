using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interface;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationInject(this IServiceCollection services)
        {
            services.AddScoped<ICalculateFreight, CalculateFreight>();
        }
    }

}
