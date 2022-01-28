using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZeroFriction.Core.SharedEntities;

namespace ZeroFriction.API.Dto
{
    public class CustomerDto
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }

        public List<AdditionalCustomerInformation> AdditionalCustomerInformation { get; set; }
    }
}
