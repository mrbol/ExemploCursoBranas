using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public int IdItem { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public OrderItem(int idItem, decimal price, int quantity)
        {
            if (quantity <= 0)
            {
                throw new AppException("Invalid quantity");
            }

            IdItem = idItem;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotal() {
            return Price * Quantity;
        }
    }
}
