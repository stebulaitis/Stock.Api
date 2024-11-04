using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Data.SqlServer.Context;

namespace Stock.CrossCutting.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<StockContext>(option =>
            {
                option.UseSqlServer(GetDatabaseConnectionString(configuration), mig => mig.MigrationsAssembly("Stock.Data.SqlServer"));
                option.EnableThreadSafetyChecks(false);
            });
        }

        public static string? GetDatabaseConnectionString(IConfiguration configuration)
        {
            var envConnStrName = "StockConnection";

            var connStr = configuration.GetConnectionString(envConnStrName);

            if (string.IsNullOrEmpty(connStr))
            {
                throw new InvalidOperationException($"The environment variable {envConnStrName} was not setted");
            }

            return connStr;
        }
    }
}
