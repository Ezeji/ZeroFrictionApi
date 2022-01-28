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
    public class CustomerService : ICustomerService
    {
        private readonly IDataRepository<Customer> _customerRepository;

        public CustomerService(IDataRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository
                             ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<OperationResponse<Customer>> CreateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                return new OperationResponse<Customer>()
                                       .SetAsFailureResponse(OperationErrorDictionary.Customer.CustomerIsNull());
            }

            customer.Id = Guid.NewGuid().ToString();

            Customer createdCustomer = await _customerRepository.AddAsync(customer);

            return new OperationResponse<Customer>(createdCustomer);
        }

        public async Task<OperationResponse<Customer>> GetCustomerByIdAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return new OperationResponse<Customer>()
                                       .SetAsFailureResponse(OperationErrorDictionary.Customer.CustomerIsNull());
            }

            Customer retrievedCustomer = await _customerRepository.GetAsync(customerId);

            if (retrievedCustomer == null)
            {
                return new OperationResponse<Customer>()
                                       .SetAsFailureResponse(OperationErrorDictionary.Customer.CustomerNotFound());
            }

            return new OperationResponse<Customer>(retrievedCustomer);
        }

        public async Task<OperationResponse<Customer>> UpdateCustomerAsync(Customer customer, string customerId)
        {
            if (customer == null || string.IsNullOrEmpty(customerId))
            {
                return new OperationResponse<Customer>()
                                       .SetAsFailureResponse(OperationErrorDictionary.Customer.CustomerIsNull());
            }

            customer.Id = customerId;

            Customer updatedCustomer = await _customerRepository.UpdateAsync(customer);

            return new OperationResponse<Customer>(updatedCustomer);
        }


    }
}
