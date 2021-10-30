using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EfCoreDemo.ModelBilder
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
               .Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(20);

            //builder.HasKey(x => x.EId, x.EGN); //<- avoid using string ("EId") always use predicat wehn is posoble. Cant do composite Key whit attributes

            builder
                .Property(x => x.StartWorkDate)
                .HasColumnName("StartedOn")
                .HasColumnType("CHAR(48)"); // <-- avoid this

            builder
                .Property(x => x.EGN)
                .HasColumnType("CHAR(6)");

            builder.Ignore(x => x.FullName); // can use attribute for ignor property [NotMapped]

            builder
                .HasOne(x => x.Department)
                .WithMany(e => e.Emploeeys)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.FirstName)
                .IsUnicode(false);

           

        }
    }
}
