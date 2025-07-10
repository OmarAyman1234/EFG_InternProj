using OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Data.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=OMARSLAPTOP\SQLEXPRESS; Initial Catalog=Trade;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
