using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public class FreightCalculator
    {
        private const int MIN_FREIGHT = 10; 
        public static decimal Calculate(Item item)
        {
            var freight = item.GetVolume() * 1000 * (item.GetDensity() / 100);
            if (freight == 0) return 0;
            return Math.Max(freight, MIN_FREIGHT);
        }
    }
}
