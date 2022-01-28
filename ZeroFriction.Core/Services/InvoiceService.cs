using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFriction.Core.Common;
using ZeroFriction.Core.Entities;
using ZeroFriction.Core.Interfaces;

namespace ZeroFriction.Core.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IDataRepository<Invoice> _invoiceRepository;
        private readonly ICustomerService _customerService;

        public InvoiceService(IDataRepository<Invoice> invoiceRepository, ICustomerService customerService)
        {
            _invoiceRepository = invoiceRepository
                             ?? throw new ArgumentNullException(nameof(invoiceRepository));

            _customerService = customerService
                             ?? throw new ArgumentNullException(nameof(customerService));
        }

        public async Task<OperationResponse<Invoice>> CreateInvoiceAsync(Invoice invoice, string customerId)
        {
            if (invoice == null || string.IsNullOrEmpty(customerId))
            {
                return new OperationResponse<Invoice>()
                                       .SetAsFailureResponse(OperationErrorDictionary.Invoice.InvoiceIsNull());
            }

            OperationResponse<Customer> retrievedCustomer = await _customerService.GetCustomerByIdAsync(customerId);

            if (retrievedCustomer.Result == null)
            {
                return new OperationResponse<Invoice>()
                                       .SetAsFailureResponse(OperationErrorDictionary.Customer.CustomerNotFound());
            }

            invoice.Id = Guid.NewGuid().ToString();
            invoice.Date = DateTime.UtcNow;
            invoice.Customer = retrievedCustomer.Result;

            Invoice createdInvoice = await _invoiceRepository.AddAsync(invoice);

            return new OperationResponse<Invoice>(createdInvoice);
        }

        public async Task<OperationResponse<Invoice>> UpdateInvoiceAsync(Invoice invoice, string invoiceId, string customerId)
        {
            if (invoice == null || string.IsNullOrEmpty(invoiceId) || string.IsNullOrEmpty(customerId))
            {
                return new OperationResponse<Invoice>()
                                       .SetAsFailureResponse(OperationErrorDictionary.Invoice.InvoiceIsNull());
            }

            OperationResponse<Customer> retrievedCustomer = await _customerService.GetCustomerByIdAsync(customerId);

            if (retrievedCustomer.Result == null)
            {
                return new OperationResponse<Invoice>()
                                       .SetAsFailureResponse(OperationErrorDictionary.Customer.CustomerNotFound());
            }

            invoice.Id = invoiceId;
            invoice.Date = DateTime.UtcNow;
            invoice.Customer = retrievedCustomer.Result;

            Invoice updatedInvoice = await _invoiceRepository.UpdateAsync(invoice);

            return new OperationResponse<Invoice>(updatedInvoice);
        }

    }
}
