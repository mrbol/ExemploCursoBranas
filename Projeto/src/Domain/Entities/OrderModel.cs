using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderModel
    {
        public int id_order { get; set; }
        public string coupon_code { get; set; }
        public decimal coupon_percentage { get; set; }
        public string code { get; set; }
        public string cpf { get; set; }
        public DateTime issue_date { get; set; }
        public decimal freight { get; set; }
        public int sequence { get; set; }
        public decimal total { get; set; }
    }
}
