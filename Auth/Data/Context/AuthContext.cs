using Microsoft.EntityFrameworkCore;
using Auth.Models;

namespace Auth.Data.Context
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=OMARSLAPTOP\SQLEXPRESS; Initial Catalog=Trade;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
} 