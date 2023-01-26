using Inicial.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using Inicial;
using System.Security.Cryptography.Xml;

namespace API.Inicial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPreviewController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderPreviewController(IOrderService orderService)
        {
            _orderService= orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderPreviewSend orderPreviewSend)
        {
            OrderPreviewResponse response = await _orderService.Execute(orderPreviewSend);
            return Ok(new OrderPreviewResponse() { Total = response.Total });
        }
    }
}
