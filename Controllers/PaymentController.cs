using E_handel.Payment.Interfaces;
using E_handel.Payment.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_handel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(OrderRequest order)
        {
            try
            {
                var klarnaResponse = await _paymentService.CreateOrderAsync(order);
                return Ok(klarnaResponse);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}