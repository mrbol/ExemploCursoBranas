using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface;

namespace Application
{
    public class DecrementStock : IDecrementStock
    {
        private readonly IStockEntryRepository _stockEntryRepository;

        public DecrementStock(IStockEntryRepository stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }
        public async Task Execute(List<StockSend> stockSend)
        {
            foreach (var stockEntryData in stockSend)
            {
                var stockEntries = await _stockEntryRepository.ListByIdItem(stockEntryData.IdItem);
                var total = StockCalculator.Calculate(stockEntries);
                if (total < stockEntryData.Quantity)
                {
                    throw new AppException("Insufficient stock");
                }
                await _stockEntryRepository.Save(new StockEntry(stockEntryData.IdItem, "out", stockEntryData.Quantity));
            }
        }
    }
}
