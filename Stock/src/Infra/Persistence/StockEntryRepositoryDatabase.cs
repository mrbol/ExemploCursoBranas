using Domain.Entity;
using Domain.Interface;

namespace Infra.Persistence
{
    public class StockEntryRepositoryDatabase : IStockEntryRepository
    {
        private readonly IDapperAdapter _dapperAdapter;
        public StockEntryRepositoryDatabase(IDapperAdapter dapperAdapter)
        {
            _dapperAdapter = dapperAdapter;
        }
        public async Task Clear()
        {
            await _dapperAdapter.Execute("delete from ccca_stock.stock_entry");
        }

        public async Task<List<StockEntry>> ListByIdItem(int id)
        {
            var stockEntriesData = await _dapperAdapter.Query<StockEntryModel>($"select * from ccca_stock.stock_entry where id_item ={id} ");
            List<StockEntry> stockEntries = new List<StockEntry>();
            foreach (var stockEntryData in stockEntriesData)
            {
                stockEntries.Add(new StockEntry(stockEntryData.id_item, stockEntryData.operation, stockEntryData.quantity));
            }

            return stockEntries;
        }

        public async Task Save(StockEntry stockEntry)
        {
            var parameter = new
            {
                id_item = stockEntry.IdItem,
                operation = stockEntry.Operation,
                quantity = stockEntry.Quantity
            };
            string Statement = "insert into ccca_stock.stock_entry (id_item, operation, quantity) values (@id_item, @operation, @quantity)";
            await _dapperAdapter.Execute(Statement, parameter);
        }
    }
}
