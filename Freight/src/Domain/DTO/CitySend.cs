using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CitySend
    {
        public CitySend()
        {
            OrderItems = new List<OrderItemSend>();
        }
        public string From { get; set; }
        public string To { get; set; }
        public List<OrderItemSend> OrderItems { get; set; }
    }
}
