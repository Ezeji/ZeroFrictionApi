using Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroFriction.Core.Entities;
using ZeroFriction.Core.Interfaces;
using ZeroFriction.Core.Services;
using ZeroFriction.Infrastructure.Configuration.Interfaces;
using ZeroFriction.Infrastructure.Data;

namespace ZeroFriction.API.Core.DependencyInjection
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {

            services.TryAddSingleton(implementationFactory =>
            {
                var cosmoDbConfiguration = implementationFactory.GetRequiredService<ICosmosDbConfiguration>();
                CosmosClient cosmosClient = new CosmosClient(cosmoDbConfiguration.ConnectionString);
                CosmosDatabase database = cosmosClient.CreateDatabaseIfNotExistsAsync(cosmoDbConfiguration.DatabaseName)
                                                       .GetAwaiter()
                                                       .GetResult();
                database.CreateContainerIfNotExistsAsync(
                    cosmoDbConfiguration.CustomerContainerName,
                    cosmoDbConfiguration.CustomerContainerPartitionKeyPath,
                    400)
                    .GetAwaiter()
                    .GetResult();

                database.CreateContainerIfNotExistsAsync(
                    cosmoDbConfiguration.InvoiceContainerName,
                         cosmoDbConfiguration.InvoiceContainerPartitionKeyPath,
                    400)
                    .GetAwaiter()
                    .GetResult();

                return cosmosClient;
            });

            services.AddSingleton<IDataRepository<Customer>, CustomerRepository>();
            services.AddSingleton<IDataRepository<Invoice>, InvoiceRepository>();
            
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IInvoiceService, InvoiceService>();

            return services;
        }
    }
}
