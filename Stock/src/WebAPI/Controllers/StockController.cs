using Domain.DTO;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IIncrementStock _incrementStock;
        private readonly IDecrementStock _decrementStock;
        private readonly IGetStock _getStock;

        public StockController(IIncrementStock incrementStock, IDecrementStock decrementStock, IGetStock getStock)
        {
            _decrementStock = decrementStock;
            _getStock = getStock;
            _incrementStock = incrementStock;
        }

        [HttpPost("IncrementStock")]
        public async Task<IActionResult> IncrementStock(List<StockSend> stockSend)
        {
            await _incrementStock.Execute(stockSend);
            return Ok();
        }
        [HttpPost("DecrementStock")]
        public async Task<IActionResult> DecrementStock(List<StockSend> stockSend)
        {
            await _decrementStock.Execute(stockSend);
            return Ok();
        }

        [HttpGet("{idItem}")]
        public async Task<IActionResult> GetStock(int idItem)
        {
            return Ok(await _getStock.Execute(idItem));
        }
    }
}
