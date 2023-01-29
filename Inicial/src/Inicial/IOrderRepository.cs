using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public interface IOrderRepository
    {
        Task save(Order order);
    }
}
