using Auth.Domain;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=host.docker.internal;Initial Catalog=Trade;User Id=efg-trade;Password=omar1234;TrustServerCertificate=true;");
        }
    }
} 