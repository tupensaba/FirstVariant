using Microsoft.EntityFrameworkCore;

namespace FirstVariant.Models
{
    public class GoodsAndOrdersDbContext:DbContext
    {
        public GoodsAndOrdersDbContext(DbContextOptions<GoodsAndOrdersDbContext> options) : base(options)
        {

        }
        public DbSet<CustomersModel> Customers { get; set; }
        public DbSet<GoodsModel> Goods { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderMaster> OrderMaster { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomersModel>().HasData(
            new { CustomerId = 1, CustomerName = "Александр"},
            new { CustomerId = 2, CustomerName = "Татьяна"},
            new { CustomerId = 3, CustomerName = "Иван"},
            new { CustomerId = 4, CustomerName = "Владислав"},
            new { CustomerId = 5, CustomerName = "Алексей"},
            new { CustomerId = 6, CustomerName = "Анастасия" });

            modelBuilder.Entity<GoodsModel>().HasData(
               new { GoodItemId = 1, GoodItemName = "Шкаф", Price = new decimal (13050.00) },
               new { GoodItemId = 2, GoodItemName = "Стул", Price = new decimal(3050.00) },
               new { GoodItemId = 3, GoodItemName = "Диван", Price = new decimal(23410.00) },
               new { GoodItemId = 4, GoodItemName = "Компьютерный стол", Price = new decimal(7250.00) },
               new { GoodItemId = 5, GoodItemName = "Карниз", Price = new decimal(3050.00) },
               new { GoodItemId = 6, GoodItemName = "Бетон", Price = new decimal(350.00) });

        }
    }
}
