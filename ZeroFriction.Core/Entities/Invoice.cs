using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZeroFriction.Core.SharedEntities;

namespace ZeroFriction.Core.Entities
{
    public class Invoice : BaseEntity
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [JsonPropertyName("additionalInvoiceInformation")]
        public List<AdditionalInvoiceInformation> AdditionalInvoiceInformation { get; set; }
    }
}
