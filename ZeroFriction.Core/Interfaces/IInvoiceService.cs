using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFriction.Core.Common;
using ZeroFriction.Core.Entities;

namespace ZeroFriction.Core.Interfaces
{
    public interface IInvoiceService
    {
        Task<OperationResponse<Invoice>> CreateInvoiceAsync(Invoice invoice, string customerId);
        Task<OperationResponse<Invoice>> UpdateInvoiceAsync(Invoice invoice, string invoiceId, string customerId);
    }
}
