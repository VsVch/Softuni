using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Descreption { get; set; }

        public Employee Employee { get; set; }
    }
}
