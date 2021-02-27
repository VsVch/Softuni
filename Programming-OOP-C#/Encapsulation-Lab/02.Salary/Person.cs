using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        {
            get 
            {
                return this.firstName;
            }
            set 
            {
                this.firstName = value;
            } 
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return $"{firstName} {LastName} receives {Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal percentage) 
        {
            decimal increaseSalary = Salary * percentage / 100;

            if (this.Age < 30 ) 
            {
                increaseSalary *= 0.5m;            
            }

            this.Salary += increaseSalary;
        
        }
    }
}
