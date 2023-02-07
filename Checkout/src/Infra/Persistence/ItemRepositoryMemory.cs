using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Domain.Entities;
using Domain.Interface;

namespace Infra.Persistence
{
    public class ItemRepositoryMemory : IItemRepository
    {
        private List<Item> _items;        

        public ItemRepositoryMemory()
        {            
            _items = new List<Item>() {
                new Item(1,"Guitarra",1000,new Dimension(100,30,10,3)),
                new Item(2,"Amplificador",5000,new Dimension(50,50,50,20)),
                new Item(2,"Cabo",30,new Dimension(10,10,10,1))
            };
        }

        public async Task<Item> GetItem(int idItem)
        {
            await Task.Delay(1);
            Item? item = _items.SingleOrDefault(p => p.IdItem == idItem);
            if (item == null)
            {
                throw new Exception("Item not found");
            }
            return item;
        }
    }
}
