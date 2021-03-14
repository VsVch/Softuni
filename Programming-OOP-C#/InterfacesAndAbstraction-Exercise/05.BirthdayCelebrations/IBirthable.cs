using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public interface IBirthable
    {
        public string Name { get;}
        public string Birthdate { get; set; }
    }
}
