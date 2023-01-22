using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public class Coupon
    {
        public string Code { get; set; }
        public decimal Percentage { get; set; }

        public Coupon(string code, decimal percentage)
        {
            Code = code;
            Percentage = percentage;
        }

        public decimal GetDiscount(decimal total)
        {
            return (total * Percentage) / 100;
        }
    }
}
