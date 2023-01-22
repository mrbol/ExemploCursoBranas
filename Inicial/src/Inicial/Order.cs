using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public class Order
    {
        private Coupon _coupon;
        private List<OrderItem> _orderItems;
        private Cpf _cpf;

        public Order(string cpf)
        {
            _cpf = new Cpf(cpf);
            _orderItems = new List<OrderItem>();
        }

        public void AddItem(Item item, int quantity)
        {
            _orderItems.Add(new OrderItem(item.IdItem, item.Price, quantity));
        }

        public void AddCoupon(Coupon coupon)
        {
            _coupon = coupon;
        }
        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (OrderItem item in _orderItems)
            {
                total += item.GetTotal();
            }
            if (_coupon != null)
            {
                total -= _coupon.GetDiscount(total);
            }
            return total;
        }

    }
}
