using System.Collections.Generic;


namespace EfCoreDemo.Models
{
    public class Department
    {
        public Department()
        {
            Emploeeys = new HashSet<Employee>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Emploeeys { get; set; }
    }
}
