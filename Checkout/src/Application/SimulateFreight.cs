using Domain.DTO;
using Domain.Entities;
using Domain.Interface;

namespace Application
{
    public class SimulateFreight
    {
        private readonly ICalculateFreightGateway _calculateFreightGateway;
        private readonly IItemRepository _itemRepository;
        public SimulateFreight(IItemRepository itemRepository, ICalculateFreightGateway calculateFreightGateway)
        {
            _itemRepository = itemRepository;
            _calculateFreightGateway = calculateFreightGateway;
        }

        public async Task<FreightResponse> Execute(FreightSend freightSend)
        {
            List<OrderItemGatewaySend> orderItemsSend = new List<OrderItemGatewaySend>();
            foreach (OrderItemSend orderItem in freightSend.OrdemItems)
            {
                Item item = await _itemRepository.GetItem(orderItem.IdItem);
                orderItemsSend.Add(new OrderItemGatewaySend() { Volume = (double)item.GetVolume(), Density = (double)item.GetDensity(), Quantity = (double)orderItem.Quantity });
            }
            FreightGatewayResponse response = await _calculateFreightGateway.Calculate(new FreightGatewaySend() { 
                From = freightSend.From,
                To = freightSend.To,
                OrderItems = orderItemsSend
            });

            return new FreightResponse() { Total = (decimal)response.Total };

        }
    }
}
