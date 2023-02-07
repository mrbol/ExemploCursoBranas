using Domain.DTO;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICheckout _checkout;
        public OrderController(ICheckout checkout)
        {
            _checkout= checkout;
        }
        [HttpPost]
        public async Task<IActionResult> Post (OrderSend orderSend) {
            OrderResponse response = await _checkout.Execute(orderSend);
            return Ok(response);
        }
    }
}
