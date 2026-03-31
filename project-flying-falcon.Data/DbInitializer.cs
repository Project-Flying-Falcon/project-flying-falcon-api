using Flying.Falcon.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Flying.Falcon.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModelBuilder builder)
        {
            // Seed data — this is the starting data in the database
            // Think of it like INSERT statements that run automatically
            builder.Entity<Item>().HasData(
                new Item("Shirt", "Ohio State shirt.", "Nike", 29.99M)
                {
                    Id = 1
                },
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
                {
                    Id = 2
                }
            );
        }
    }
}