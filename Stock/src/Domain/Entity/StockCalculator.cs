using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class StockCalculator
    {
        public static int Calculate(List<StockEntry> stockEntries)
        {
            int total = 0;
            foreach (StockEntry item in stockEntries)
            {
                if (item.Operation == "in")
                {
                    total += item.Quantity;
                }
                if (item.Operation == "out")
                {
                    total -= item.Quantity;
                }
            }
            return total;
        }
    }

}
