using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Class |
        AttributeTargets.Method)]
   public class StudentAtribute : Attribute
    {

        public StudentAtribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        
    }
}
