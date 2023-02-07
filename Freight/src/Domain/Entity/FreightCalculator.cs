using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class FreightCalculator
    {
       public const int MIN_FREIGHT = 10;

        public static double Calculate(double distance, double volume, double density) {
            var freight = volume * distance * (density / 100);
            if(freight == 0) return 0;
            return Math.Max(freight, MIN_FREIGHT);
        }
    }
}
