using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class FreightGatewaySend
    {
        public FreightGatewaySend()
        {
            OrderItems = new List<OrderItemGatewaySend>();
        }
        public string From { get; set; }
        public string To { get; set; }
        public List<OrderItemGatewaySend> OrderItems { get; set; }
    }
}
