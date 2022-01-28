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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService
                                     ?? throw new ArgumentNullException(nameof(invoiceService));
        }

        /// <summary>
        /// Create new invoice
        /// </summary>
        /// <response code="200">Created invoice</response>
        /// <response code="400">Invoice not created</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(Invoice), 200)]
        [HttpPost("create/{customerId}")]
        public async Task<IActionResult> PostInvoiceAsync([FromBody] InvoiceDto invoiceDto, [FromRoute] string customerId)
        {
            Invoice invoice = InvoiceMapper.MapFromDto(invoiceDto);
            OperationResponse<Invoice> operationResponse = await _invoiceService.CreateInvoiceAsync(invoice, customerId);

            if (!operationResponse.CompletedWithSuccess)
            {
                return BadRequest(operationResponse.OperationError);
            }

            return Ok(operationResponse.Result);
        }

        /// <summary>
        /// Update existing invoice
        /// </summary>
        /// <response code="200">Updated invoice</response>
        /// <response code="400">Invoice not updated</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(Customer), 200)]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateInvoiceAsync([FromBody] InvoiceDto invoiceDto, [FromQuery] string invoiceId, [FromQuery] string customerId)
        {
            Invoice invoice = InvoiceMapper.MapFromDto(invoiceDto);
            OperationResponse<Invoice> operationResponse = await _invoiceService.UpdateInvoiceAsync(invoice, invoiceId, customerId);

            if (!operationResponse.CompletedWithSuccess)
            {
                return BadRequest(operationResponse.OperationError);
            }

            return Ok(operationResponse.Result);
        }

    }
}
