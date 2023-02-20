using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entity;

namespace Domain.Interface
{
    public interface IIncrementStock
    {
        Task Execute(List<StockSend> stockSend);
    }
}
