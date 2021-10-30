using EfCoreDemo.ModelBilder;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Emploeeys { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<EmployeeInClub> EmployeesInClubs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; User Id=sa;Password=@Stefanov820605; Database=IfCoreDemo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(x => x.Salary).HasPrecision(12, 3);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.Entity<Address>()
                .HasOne(x => x.Employee)
                .WithOne(x => x.Address);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(x => x.Department)
            //    .WithMany(e => e.Emploeeys)
            //    .HasForeignKey(x => x.Department)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Department>()
            //    .HasMany(x => x.Emploeeys)
            //    .WithOne(x => x.Department)
            //    .HasForeignKey(x => x.DepartmentId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeInClub>().HasKey(x => new { x.EmployeeId, x.ClubId });
        }
    }
}
