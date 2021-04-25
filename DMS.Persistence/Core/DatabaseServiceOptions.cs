using System;

namespace Persistence.Core
{
    public class DatabaseServiceOptions : IDatabaseServiceOptions
    {
        public string ConnectionString { get; set; }
        public IServiceProvider Provider { get; set; }
    }
}
