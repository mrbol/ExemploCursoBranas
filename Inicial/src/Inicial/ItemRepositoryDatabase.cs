using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inicial
{
    public class ItemRepositoryDatabase : IItemRepository
    {
        private readonly IConfiguration _configuration;
        public ItemRepositoryDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Item> GetItem(int idItem)
        {
            Item item = new Item();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                string query = $"Select id_item,description,price,width,height,length,weight from ccca.item where id_item = {idItem}";
                IEnumerable<ItemModel> itemModels = await connection.QueryAsync<ItemModel>(query);
                ItemModel? itemModel = (itemModels.Any()) ? itemModels.FirstOrDefault() : null;
                if (itemModel != null)
                {
                    item = new Item(itemModel.id_item, itemModel.description, itemModel.price, new Dimension(itemModel.width, itemModel.height, itemModel.length, itemModel.weight));                    
                }
                await connection.CloseAsync();
            }
            return item;
        }
    }
}
