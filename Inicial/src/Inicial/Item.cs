using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public class Item
    {
        private Dimension _dimension;

        public int IdItem { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Dimension Dimension
        {
            get => _dimension;
            set => _dimension = (value != null) ? value : new Dimension();
        }

        public Item(int idItem, string description, decimal price, Dimension? dimension = default)
        {
            IdItem = idItem;
            Description = description;
            Price = price;
            this.Dimension = dimension;
        }

        public decimal GetVolume()
        {
            return this.Dimension.GetVolume();
        }
        public decimal GetDensity()
        {
            return this.Dimension.GetDensity();
        }


    }
}
