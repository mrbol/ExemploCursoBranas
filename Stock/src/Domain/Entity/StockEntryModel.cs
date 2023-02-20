using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class StockEntryModel
    {
        public StockEntryModel() {
            operation = string.Empty;
        }
        public int id_stock_entry { get; set; }
        public int id_item { get; set; }
        public string operation { get; set; }
        public int quantity { get; set; }
    }
}
