using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logger
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public void InitializeContainer(IServiceCollection services, IConfiguration configuration)
        {
            string storageAccount = configuration["Azure.StorageAccount"];
            string storageKey = configuration["Azure.StorageKey"];
            string auditTableName = configuration["Azure.Audit.TableName"];
            string logTableName = configuration["Azure.Logging.TableName"];


            services.AddScoped<IAzureTableStorage<LoggingDebugMessage>>(factory =>
            {
                return new AzureTableStorage<LoggingDebugMessage>(
                    new AzureTableSettings(
                        storageAccount: storageAccount,
                        storageKey: storageKey,
                        tableName: logTableName));
            });

            services.AddScoped<IApplicationLogger, ApplicationLogger>();
        }
    }
}
