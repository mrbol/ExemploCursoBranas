using Domain.Entity;
using Domain.Interface;

namespace Application
{
    public class GetStock : IGetStock
    {
        private readonly IStockEntryRepository _stockEntryRepository;
        public GetStock(IStockEntryRepository stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }

        public async Task<int> Execute(int idItem)
        {
            var stockEntries = await _stockEntryRepository.ListByIdItem(idItem);
            return StockCalculator.Calculate(stockEntries);
        }
    }
}
