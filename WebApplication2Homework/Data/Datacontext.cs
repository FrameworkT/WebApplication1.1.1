using Microsoft.EntityFrameworkCore;

namespace WebApplication2Homework.Data
{
    public class Datacontext :DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Product> Products { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //override method เอา method ที่มีอยู่เเล้วมาเขียนเพิ่ม
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-DTGB06O\\SQLEXPRESS; Database=Homeworkja; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
