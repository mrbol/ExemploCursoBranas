using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entities;
using Domain.Interface;

namespace Application
{
    public class PreviewOrder:IPreviewOrder
    {
        private readonly IItemRepository _itemRepository;
        public PreviewOrder(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<OrderPreviewResponse> Execute(OrderPreviewSend orderPreview)
        {
            Order order = new Order(orderPreview.Cpf);
            foreach (OrderItemSend orderItem in orderPreview.OrderItens)
            {
                Item item = await _itemRepository.GetItem(orderItem.IdItem);
                order.AddItem(item, orderItem.Quantity);
            }
            return new OrderPreviewResponse() { Total = order.GetTotal() };
        }
    }
}
