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
        private readonly IPreviewOrder _previewOrder;
        public OrderPreviewController(IPreviewOrder previewOrder)
        {
            _previewOrder= previewOrder;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderPreviewSend orderPreviewSend)
        {
            OrderPreviewResponse response = await _previewOrder.Execute(orderPreviewSend);
            return Ok(new OrderPreviewResponse() { Total = response.Total });
        }
    }
}
