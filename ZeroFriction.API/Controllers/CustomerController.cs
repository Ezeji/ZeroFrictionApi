using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroFriction.API.Dto;
using ZeroFriction.API.Mappers;
using ZeroFriction.Core.Common;
using ZeroFriction.Core.Entities;
using ZeroFriction.Core.Interfaces;

namespace ZeroFriction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService
                                     ?? throw new ArgumentNullException(nameof(customerService));
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <response code="200">Created customer</response>
        /// <response code="400">Customer not created</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(Customer), 200)]
        [HttpPost("create")]
        public async Task<IActionResult> PostCustomerAsync([FromBody] CustomerDto customerDto)
        {
            Customer customer = CustomerMapper.MapFromDto(customerDto);
            OperationResponse<Customer> operationResponse = await _customerService.CreateCustomerAsync(customer);

            if (!operationResponse.CompletedWithSuccess)
            {
                return BadRequest(operationResponse.OperationError);
            }

            return Ok(operationResponse.Result);
        }

        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <response code="200">Updated customer</response>
        /// <response code="400">Customer not updated</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(Customer), 200)]
        [HttpPut("update/{customerId}")]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] CustomerDto customerDto, [FromRoute] string customerId)
        {
            Customer customer = CustomerMapper.MapFromDto(customerDto);
            OperationResponse<Customer> operationResponse = await _customerService.UpdateCustomerAsync(customer, customerId);

            if (!operationResponse.CompletedWithSuccess)
            {
                return BadRequest(operationResponse.OperationError);
            }

            return Ok(operationResponse.Result);
        }

    }
}
