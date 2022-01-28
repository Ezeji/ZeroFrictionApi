using Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFriction.Core.Entities;
using ZeroFriction.Infrastructure.Configuration.Interfaces;

namespace ZeroFriction.Infrastructure.Data
{
    public class CustomerRepository : CosmosDbDataRepository<Customer>
    {
        public CustomerRepository(ICosmosDbConfiguration cosmosDbConfiguration,
                         CosmosClient client) : base(cosmosDbConfiguration, client)
        {
        }

        public override string ContainerName => _cosmosDbConfiguration.CustomerContainerName;
    }
}
