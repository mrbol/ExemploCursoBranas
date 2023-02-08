using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entities;

namespace Domain.DTO
{
    public class FreightSend
    {
        public string From { get; set; }
        public string To { get; set; }
        public List<OrderItemSend> OrdemItems { get; set; }

        public FreightSend()
        {
            OrdemItems = new List<OrderItemSend>();
        }

    }
}
