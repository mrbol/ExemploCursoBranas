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
        public List<OrderItemSend> OrdemItems { get; set; }

        public FreightSend()
        {
            OrdemItems = new List<OrderItemSend>();
        }

    }
}
