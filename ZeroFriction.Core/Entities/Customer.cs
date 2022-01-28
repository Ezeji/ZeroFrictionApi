using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZeroFriction.Core.SharedEntities;

namespace ZeroFriction.Core.Entities
{
    public class Customer : BaseEntity
    {
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("additionalCustomerInformation")]
        public List<AdditionalCustomerInformation> AdditionalCustomerInformation { get; set; }
    }

}
