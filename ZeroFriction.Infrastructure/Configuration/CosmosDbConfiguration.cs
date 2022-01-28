using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFriction.Infrastructure.Configuration.Interfaces;

namespace ZeroFriction.Infrastructure.Configuration
{
    public class CosmosDbConfiguration : ICosmosDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CustomerContainerName { get; set; }
        public string CustomerContainerPartitionKeyPath { get; set; }
        public string InvoiceContainerName { get; set; }
        public string InvoiceContainerPartitionKeyPath { get; set; }
    }

    public class CosmosDbConfigurationValidation : IValidateOptions<CosmosDbConfiguration>
    {
        public ValidateOptionsResult Validate(string name, CosmosDbConfiguration options)
        {
            if (string.IsNullOrEmpty(options.ConnectionString))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ConnectionString)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.CustomerContainerName))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.CustomerContainerName)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.InvoiceContainerName))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.InvoiceContainerName)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.DatabaseName))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.DatabaseName)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.CustomerContainerPartitionKeyPath))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.CustomerContainerPartitionKeyPath)} configuration parameter for the Azure Cosmos DB is required");
            }

            if (string.IsNullOrEmpty(options.InvoiceContainerPartitionKeyPath))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.InvoiceContainerPartitionKeyPath)} configuration parameter for the Azure Cosmos DB is required");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
