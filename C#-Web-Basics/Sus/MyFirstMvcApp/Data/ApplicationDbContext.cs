using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {}

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {}

        public DbSet<Card> Cards { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCard> UserCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; User Id=sa;Password=@Stefanov820605; Database=BattleCards");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCard>().HasKey(x => new {x.UserId, x.CardId });
        }

        
    }
}
