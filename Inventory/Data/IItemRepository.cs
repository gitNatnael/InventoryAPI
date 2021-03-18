using Inventory.Models;
using System;
using System.Collections.Generic;

namespace Inventory.Data
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        Item GetItem(Guid id);
        void AddItem(Item item);
        void DeleteItem(Guid id);
    }
}
