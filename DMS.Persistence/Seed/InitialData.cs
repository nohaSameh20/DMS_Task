using System;

namespace Persistence.Core
{
    public class InitialData
    {
        public static void Seed(IServiceProvider provider, IDatabaseServiceOptions options)
        {
            DatabaseService databaseService = new DatabaseService(provider, options);

            databaseService.Database.EnsureCreated();

            Execute(databaseService);
        }

        private static void Execute(DatabaseService databaseService)
        {
        }
    }
}