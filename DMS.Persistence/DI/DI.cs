using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Persistence.Core;

namespace Persistence
{
    public static class DI
    {

        public static void RegisterPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDatabaseServiceOptions>(provider => new DatabaseServiceOptions() { ConnectionString = connectionString, Provider = services.BuildServiceProvider() });

            services.AddScoped<IDatabaseService, DatabaseService>(); 
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

           // InitialData.Seed(services.BuildServiceProvider(), new DatabaseServiceOptions() { ConnectionString = connectionString, Provider = services.BuildServiceProvider() });
        }
    }
}