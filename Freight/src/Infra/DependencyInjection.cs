using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<ICityRepository, CityRepositoryDatabase>();
        }
    }
}
