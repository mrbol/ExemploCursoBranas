using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Inicial.DTO;

namespace Inicial
{
    public class OrderService:IOrderService
    {
        private readonly IItemRepository _itemRepository;
        public OrderService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<OrderPreviewResponse> Execute(OrderPreviewSend input)
        {
            Order order = new Order(input.Cpf);
            foreach (OrderItemSend orderItem in input.OrderItens)
            {
                Item item = await _itemRepository.GetItem(orderItem.IdItem);
                order.AddItem(item, orderItem.Quantity);
            }   
            return new OrderPreviewResponse() { Total = order.GetTotal() };
        }
    }

}
