using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZeroFriction.Core.SharedEntities
{
    public class AdditionalInvoiceInformation
    {
        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("lineAmount")]
        public decimal LineAmount { get; set; }
    }
}
