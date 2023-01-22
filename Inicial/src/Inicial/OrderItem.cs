using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public class OrderItem
    {
        public int IdItem { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public OrderItem(int idItem, decimal price, int quantity)
        {
            IdItem = idItem;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotal() {
            return Price * Quantity;
        }
    }
}
