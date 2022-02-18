using Microsoft.EntityFrameworkCore;
using SMS.Data.Models;

namespace SMS.Data
{    
    // ReSharper disable once InconsistentNaming
    public class SMSDbContext : DbContext
    {
        public SMSDbContext()
        {            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(c => c.Cart)
            .WithOne(u => u.User)
            .HasForeignKey<User>(u => u.CartId);

            base.OnModelCreating(modelBuilder);
        }
    }
}