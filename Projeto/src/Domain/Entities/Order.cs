using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        private Coupon? _coupon;
        private List<OrderItem> _orderItems;
        private Cpf _cpf;
        private DateTime _date;
        private decimal _freight = 0;

        public DateTime Date
        {
            get => _date.CompareTo(default(DateTime)) == 0 ? DateTime.Now : _date;
            set => _date = value;
        }

        public Order(string cpf, DateTime date = new DateTime())
        {
            _cpf = new Cpf(cpf);
            _orderItems = new List<OrderItem>();
            Date = date;
        }

        public void AddItem(Item item, int quantity)
        {
            if (_orderItems.Exists(p => p.IdItem == item.IdItem))
            {
                throw new Exception("Duplicate item");
            }
            _orderItems.Add(new OrderItem(item.IdItem, item.Price, quantity));
            _freight += FreightCalculator.Calculate(item) * quantity;
        }

        public void AddCoupon(Coupon coupon)
        {
            if (coupon.IsExpired(Date))
            {
                return;
            }
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
            total += _freight;
            return total;
        }

    }
}
