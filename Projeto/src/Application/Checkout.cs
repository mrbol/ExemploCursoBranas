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
    public class Checkout:ICheckout
    {
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;

        public Checkout(IItemRepository itemRepository,IOrderRepository orderRepository)
        {
            _orderRepository= orderRepository;
            _itemRepository = itemRepository;
        }

        public async Task<OrderResponse> Execute(OrderSend orderSend)
        {
            int sequence = await _orderRepository.Count()+1;
            Order order = new Order(orderSend.Cpf,orderSend.Date,sequence);
            foreach (OrderItemSend orderItem in orderSend.OrderItens)
            {
                Item item = await _itemRepository.GetItem(orderItem.IdItem);
                order.AddItem(item, orderItem.Quantity);
            }
            await _orderRepository.Save(order);
            return new OrderResponse() { Total = order.GetTotal(), Code =  order.GetCode()};
        }
    }
}
