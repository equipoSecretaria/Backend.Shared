using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Backend.Shared
{
    /// <summary>
    /// Startup Data.
    /// </summary>
    public static class StartupData
    {
        /// <summary>
        /// The retry times
        /// </summary>
        private const int RETRY_TIMES = 3;

        /// <summary>
        /// The retry seconds
        /// </summary>
        private const int RETRY_SECONDS = 30;

        /// <summary>
        /// The timeout seconds
        /// </summary>
        private const int TIMEOUT_SECONDS = 60;

        /// <summary>
        /// Configure data.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <param name="connectionString">Connection string.</param>
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Repositories.Context.CommonsMySQLContext>(options =>
            {
                options.UseMySQL(configuration.GetValue<string>(Utilities.Constants.KeyVault.SQLDBTramites),
                    sqlOptions =>
                    {
                        sqlOptions.CommandTimeout(TIMEOUT_SECONDS);

                    });
            });

            services.AddDbContext<Repositories.Context.SharedSQLServerContext>(options =>
            {
                options.UseSqlServer(configuration.GetValue<string>(Utilities.Constants.KeyVault.SQLDBCommons),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(RETRY_TIMES, System.TimeSpan.FromSeconds(RETRY_SECONDS), null);
                        sqlOptions.CommandTimeout(TIMEOUT_SECONDS);

                    });
            });
            services.AddScoped(typeof(Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<>), typeof(Repositories.Base.BaseRepositorySharedSQLServer<>));
            services.AddScoped(typeof(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<>), typeof(Repositories.Base.BaseRepositoryCommonsMySQL<>));
            services.AddSingleton<Repositories.Context.OracleContext>();
        }
    }
}
