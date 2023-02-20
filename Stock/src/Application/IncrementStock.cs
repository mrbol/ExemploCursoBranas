using Domain.DTO;
using Domain.Entity;
using Domain.Interface;

namespace Application
{
    public class IncrementStock : IIncrementStock
    {
        private readonly IStockEntryRepository _stockEntryRepository;

        public IncrementStock(IStockEntryRepository stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }

        public async Task Execute(List<StockSend> stockSend)
        {
            foreach (var stockEntryData in stockSend)
            {
                await _stockEntryRepository.Save(new StockEntry(stockEntryData.IdItem, "in", stockEntryData.Quantity));
            }
        }
    }
}
