using FootballManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Data
{    
    public class FootballManagerDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }


        public DbSet<Player> Players { get; set; }


        public DbSet<UserPlayer> UsersPlayers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    ("Server=localhost; User Id=sa; Password=@Test123456; Database=FootballManager;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPlayer>().HasKey(x => new { x.UserId, x.PlayerId });
        }
    }
}
