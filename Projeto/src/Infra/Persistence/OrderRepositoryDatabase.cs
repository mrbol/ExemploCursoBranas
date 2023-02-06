using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;

namespace Infra.Persistence
{
    public class OrderRepositoryDatabase : IOrderRepository
    {
        private readonly IDapperAdapter _dapperAdapter;
        public OrderRepositoryDatabase(IDapperAdapter dapperAdapter)
        {
            _dapperAdapter = dapperAdapter;
        }

        public async Task Clean()
        {
            await _dapperAdapter.Execute("delete from ccca.[order_item]");
            await _dapperAdapter.Execute("delete from ccca.[order]");
        }

        public Task<int> Count()
        {
            return _dapperAdapter.ExecuteScalar<int>("select count(*) from ccca.[order]");
        }

        public async Task Save(Order order)
        {
            StringBuilder Statement = new StringBuilder();
            Statement.Append($" insert ccca.[order](code, cpf, issue_date, total, freight) values (@code,@cpf,@date,@total,@freight) ");
            Statement.Append($" select @@IDENTITY as 'id_order'");

            var parameter = new
            {
                code = order.GetCode(),
                cpf = order.Cpf.GetValue(),
                date = order.Date,
                total = order.GetTotal(),
                freight = order.Freight
            };

            var idOrder = await _dapperAdapter.ExecuteScalar<int>(Statement.ToString(),parameter);
            foreach (OrderItem item in order.OrderItems)
            {
                var parameterItem = new
                {
                    id_order = idOrder,
                    id_item = item.IdItem,
                    price = item.Price,
                    quantity =item.Quantity
                };
                await _dapperAdapter.Execute($"insert ccca.order_item (id_order, id_item, price, quantity) values (@id_order, @id_item, @price, @quantity)", parameterItem);
            }           
        }
    }
}
