using Inventory.Context;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly InventoryDbContext _itemContext;
        public ItemRepository(InventoryDbContext itemContext)
        {
            _itemContext = itemContext;

        }
        public void AddItem(Item item)
        {
            if (item != null)
            {
                item.ItemId = Guid.NewGuid();
                _itemContext.Items.Add(item);
                _itemContext.SaveChanges();

            }
        }

        public void DeleteItem(Guid id)
        {
            var item = GetItem(id);
            if(item != null)
            {
                _itemContext.Items.Remove(item);
                _itemContext.SaveChanges();
            }
        }

        public Item GetItem(Guid id)
        {
            return _itemContext.Items.Find(id);
        }

        public List<Item> GetItems()
        {
            return _itemContext.Items.ToList();
        }
    }
}
