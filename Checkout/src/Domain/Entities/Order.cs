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
        public Cpf Cpf;
        private DateTime _date;
        private decimal _freight=0;
        private OrderCode _code;

        public DateTime Date
        {
            get => _date.CompareTo(default(DateTime)) == 0 ? DateTime.Now : _date;
            set => _date = value;
            
        }
        public decimal Freight { get => _freight; set => _freight = value; }
        public List<OrderItem> OrderItems { get => _orderItems; set => _orderItems = value; }

        public Order(string cpf, DateTime date = new DateTime(), int sequence=1)
        {
            Cpf = new Cpf(cpf);
            OrderItems = new List<OrderItem>();
            Date = date;
            _code = new OrderCode(date, sequence);
        }

        public void AddItem(Item item, int quantity)
        {
            if (OrderItems.Exists(p => p.IdItem == item.IdItem))
            {
                throw new AppException("Duplicate item");
            }
            OrderItems.Add(new OrderItem(item.IdItem, item.Price, quantity));
            Freight += FreightCalculator.Calculate(item) * quantity;
        }

        public void AddCoupon(Coupon coupon)
        {
            if (coupon.IsExpired(Date))
            {
                return;
            }
            _coupon = coupon;
        }

        public string GetCode() {
            return _code.Value;
        }
        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (OrderItem item in OrderItems)
            {
                total += item.GetTotal();
            }
            if (_coupon != null)
            {
                total -= _coupon.GetDiscount(total);
            }
            total += Freight;
            return total;
        }

    }
}
