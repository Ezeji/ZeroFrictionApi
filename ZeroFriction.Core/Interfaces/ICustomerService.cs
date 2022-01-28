using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFriction.Core.Common;
using ZeroFriction.Core.Entities;

namespace ZeroFriction.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<OperationResponse<Customer>> CreateCustomerAsync(Customer customer);
        Task<OperationResponse<Customer>> GetCustomerByIdAsync(string customerId);
        Task<OperationResponse<Customer>> UpdateCustomerAsync(Customer customer, string customerId);
    }
}
