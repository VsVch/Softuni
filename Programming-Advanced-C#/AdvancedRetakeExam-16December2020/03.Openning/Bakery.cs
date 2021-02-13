using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Employee>(Capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Employee employee) 
        {
            if (Capacity > data.Count)
            {
                this.data.Add(employee);
            }
             // else ???        
        }

        public bool Remove(string name) 
        {
            bool isExit = false;

            if (this.data.Any(n => n.Name ==name))
            {
                Employee person = this.data.FirstOrDefault(e => e.Name == name);
                this.data.Remove(person);
                isExit = true;
            }

            return isExit;
        }

        public Employee GetOldestEmployee() 
        {
            Employee person = null;

            if (data.Count <= 0)
            {                
               
            }
            person = this.data.OrderByDescending(x => x.Age).First();
            return person;
        }
        public Employee GetEmployee(string name) 
        {
            
            if (data.Count <= 0)
            {
                
            }
            Employee person = this.data.FirstOrDefault(e => e.Name == name);
            return person;

        }
        public int Count() 
        {
            return this.data.Count;
        
        }
        public string Report()
        {
            StringBuilder personInfo = new StringBuilder();
            
            personInfo.AppendLine ($"Employees working at Bakery {this.Name}");

            foreach (var item in this.data)
            {
                personInfo.AppendLine($"Employee: {item.Name}, {item.Age} ({item.Country})");
            }
           return personInfo.ToString();
        }
    }
}
