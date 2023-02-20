using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interface
{
    public interface IStockEntryRepository
    {
        Task<List<StockEntry>> ListByIdItem(int id);
        Task Save(StockEntry stockEntry);
        Task Clear();
    }
}
