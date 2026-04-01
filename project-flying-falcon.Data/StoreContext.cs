using Flying.Falcon.Domain.Catalog;
using Flying.Falcon.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Flying.Falcon.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        // This is like a table in the database — one row per Item
        // Think of DbSet like a Java List that's backed by a real database table
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
}