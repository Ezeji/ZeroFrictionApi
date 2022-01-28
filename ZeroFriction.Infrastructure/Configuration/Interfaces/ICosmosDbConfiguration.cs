using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFriction.Infrastructure.Configuration.Interfaces
{
    public interface ICosmosDbConfiguration
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CustomerContainerName { get; set; }
        string CustomerContainerPartitionKeyPath { get; set; }
        string InvoiceContainerName { get; set; }
        string InvoiceContainerPartitionKeyPath { get; set; }
    }
}
