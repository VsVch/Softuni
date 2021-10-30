using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreDemo.Models
{
    [Index("EGN", IsUnique = true)]
    [Table("People", Schema = "company")] // -> can be added name [Table("People", Schema = "company", name = IX_Egn)]
    public class Employee
    {
        public Employee()
        {
            Clubs = new HashSet<Club>();
        }

        [Key]
        public int Id { get; set; }
              
        public string EGN { get; set; }

        [MaxLength(25)] // -> string max lenght
        public string FirstName { get; set; }

        [Required] // -> Not null
        public string LastName { get; set; }

        
        public string FullName => $"{this.FirstName + " " + this.LastName}";

        [Column("StartedOn", TypeName = "date")]
        public DateTime? StartWorkDate { get; set; }

        public decimal? Salary { get; set; }

       
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Club> Clubs { get; set; }

        public int? BirthTownId { get; set; }

        [InverseProperty(nameof(Town.NativeCitizens))]
        public Town BirthTown { get; set; }


        public int? WorkplaceTownId { get; set; }

        [InverseProperty(nameof(Town.Workers))]
        public Town WorkplaceTown { get; set; }
    }
}
