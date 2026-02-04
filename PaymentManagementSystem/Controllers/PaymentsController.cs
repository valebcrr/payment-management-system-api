using Microsoft.AspNetCore.Mvc;
using PaymentManagementSystem.Models;
using PaymentManagementSystem.Services;
using PaymentManagementSystem.DTOs;


namespace PaymentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto dto)
        {
            var result = await _service.CreatePayment(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _service.GetAllPayment();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _service.GetByIdPayment(id);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaymentsPaged([FromQuery] PaymentQueryDto query)
        {
            var result = await _service.GetPayments(query);
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, UpdatePaymentStatusDto dto)
        {
            var updated = await _service.UpdateStatus(id, dto.Status);

            if (!updated)
                return NotFound();

            return NoContent();
        }

     

    }

}
