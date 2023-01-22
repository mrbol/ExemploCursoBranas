using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Item(int idItem, string description, decimal price)
        {
            IdItem = idItem;
            Description = description;
            Price = price;

        }
    }
}
