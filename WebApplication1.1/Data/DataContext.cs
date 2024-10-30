using Microsoft.EntityFrameworkCore;

namespace WebApplication1._1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //override method เอา method ที่มีอยู่เเล้วมาเขียนเพิ่ม
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-DTGB06O\\SQLEXPRESS; Database=Database2576; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Random rnd = new Random();
            var products = new List<Product>();

            for (int i = 1; i <= 20; i++)
            {
                products.Add(new Product
                {
                    Id = i,
                    Name = "MicroPhone" + i,
                    Price = rnd.Next(10,99), 
                    Amount = rnd.Next(1, 10)
                });
            }

            modelBuilder.Entity<Product>().HasData(products);
        }

    }
}
