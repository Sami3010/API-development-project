using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet <Models.Product> Products { get; set; }
    }
}
