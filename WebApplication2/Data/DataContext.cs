using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Feature> Features { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //override method เอา method ที่มีอยู่เเล้วมาเขียนเพิ่ม
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-DTGB06O\\SQLEXPRESS; Database=DatabaseJaaa; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
