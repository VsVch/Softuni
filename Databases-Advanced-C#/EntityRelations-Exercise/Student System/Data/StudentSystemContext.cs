using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }            
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;Password=@Stefanov820605;Database=P01_StudentSystem");
            }           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.CourseId, x.StudentId });

            //modelBuilder.Entity<Homework>().HasOne(x => x.Course).WithMany(x => x.HomeworkSubmissions);

            //modelBuilder.Entity<Homework>().HasOne(x => x.Student).WithMany(x => x.HomeworkSubmissions);

        }
    }
}
