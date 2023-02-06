using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Entities;
using Domain.Interface;

namespace Infra.Persistence
{
    public class ItemRepositoryDatabase : IItemRepository
    {       
        private readonly IDapperAdapter _dapperAdapter;

        public ItemRepositoryDatabase(IDapperAdapter dapperAdapter)
        {
            _dapperAdapter = dapperAdapter;
        }

        public async Task<Item> GetItem(int idItem)
        {            
            var itemModel = await _dapperAdapter.QuerySingle<ItemModel>($"Select id_item,description,price,width,height,length,weight from ccca.item where id_item = {idItem}");
            return new Item(itemModel.id_item, itemModel.description, itemModel.price, new Dimension(itemModel.width, itemModel.height, itemModel.length, itemModel.weight));
        }
    }
}
