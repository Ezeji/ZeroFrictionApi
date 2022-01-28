using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroFriction.API.Dto;
using ZeroFriction.Core.Entities;

namespace ZeroFriction.API.Mappers
{
    public static class InvoiceMapper
    {
        public static InvoiceDto MapToDto(Invoice invoice)
        {
            return new InvoiceDto
            {
                AdditionalInvoiceInformation = invoice.AdditionalInvoiceInformation,
                TotalAmount = invoice.TotalAmount,
                Description = invoice.Description
            };
        }

        public static Invoice MapFromDto(InvoiceDto invoiceDto)
        {
            return new Invoice
            {
                AdditionalInvoiceInformation = invoiceDto.AdditionalInvoiceInformation,
                TotalAmount = invoiceDto.TotalAmount,
                Description = invoiceDto.Description
            };
        }
    }
}
