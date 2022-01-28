using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroFriction.API.Dto;
using ZeroFriction.Core.Entities;

namespace ZeroFriction.API.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto MapToDto(Customer customer)
        {
            return new CustomerDto
            {
                AdditionalCustomerInformation = customer.AdditionalCustomerInformation,
                Address = customer.Address,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname
            };
        }

        public static Customer MapFromDto(CustomerDto customerDto)
        {
            return new Customer
            {
                AdditionalCustomerInformation = customerDto.AdditionalCustomerInformation,
                Address = customerDto.Address,
                Firstname = customerDto.Firstname,
                Lastname = customerDto.Lastname
            };
        }
    }
}
