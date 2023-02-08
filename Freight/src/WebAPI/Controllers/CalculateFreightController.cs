using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateFreightController : ControllerBase
    {
        private readonly ICalculateFreight _calculateFreight;
        public CalculateFreightController(ICalculateFreight calculateFreight)
        {
            _calculateFreight = calculateFreight;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CitySend citySend) { 
            CityResponse response = await _calculateFreight.Execute(citySend);
            return Ok(response);
        }
    }
}
