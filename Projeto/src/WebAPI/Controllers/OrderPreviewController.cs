using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interface;
using Domain.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPreviewController : ControllerBase
    {
        private readonly IPreviewOrder _previewOrder;
        public OrderPreviewController(IPreviewOrder previewOrder)
        {
            _previewOrder = previewOrder;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderSend orderPreviewSend)
        {
            OrderResponse response = await _previewOrder.Execute(orderPreviewSend);
            return Ok(new OrderResponse() { Total = response.Total });
        }
    }
}
