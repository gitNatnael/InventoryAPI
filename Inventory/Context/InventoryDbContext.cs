using Inventory.Models;
using Microsoft.EntityFrameworkCore;


namespace Inventory.Context
{
    public class InventoryDbContext : DbContext
    {

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }

    }
}
