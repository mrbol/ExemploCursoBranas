using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class StockEntry
    {
        public int IdItem { get; set; }
        public string Operation { get; set; }
        public int Quantity { get; set; }

        public StockEntry(int idItem, string operation, int quantity) {
            IdItem= idItem;
            Operation= operation;
            Quantity= quantity;
        }
    }
}
