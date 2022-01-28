using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZeroFriction.Core.SharedEntities;

namespace ZeroFriction.API.Dto
{
    public class InvoiceDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public List<AdditionalInvoiceInformation> AdditionalInvoiceInformation { get; set; }
    }
}
