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
        public DateTime ExpireDate { get; set; }

        public Coupon(string code, decimal percentage, DateTime expireDate)
        {
            Code = code;
            Percentage = percentage;
            ExpireDate = expireDate;
        }

        public bool IsExpired(DateTime date)
        {
            return ExpireDate.CompareTo(date) < 0;
        }
        public decimal GetDiscount(decimal total)
        {
            return (total * Percentage) / 100;
        }
    }
}
