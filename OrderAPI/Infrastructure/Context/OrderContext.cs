using OrderAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Infrastructure.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=OMARSLAPTOP\SQLEXPRESS; Initial Catalog=Trade;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
} 