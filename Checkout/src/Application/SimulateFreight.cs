using Domain.DTO;
using Domain.Entities;
using Domain.Interface;

namespace Application
{
    public class SimulateFreight
    {
        private readonly IItemRepository _itemRepository;
        public SimulateFreight(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<FreightResponse> Execute(FreightSend freightSend)
        {
            decimal total = 0;
            foreach (OrderItemSend ordemItem in freightSend.OrdemItems)
            {
                var item = await _itemRepository.GetItem(ordemItem.IdItem);
                total += FreightCalculator.Calculate(item) * ordemItem.Quantity;
            }
            return new FreightResponse() { Total = total }; 
        }
    }
}
