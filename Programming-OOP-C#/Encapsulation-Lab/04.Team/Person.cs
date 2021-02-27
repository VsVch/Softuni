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

        public Person(string firstname, string lastName, int age, decimal salary)
        {
            this.FirstName = firstname;
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
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name must be more than 2 symbols");
                }
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
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name must be more than 2 symbols");
                }
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
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be positive number");
                }
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
                if (value < 460)
                {
                    throw new ArgumentException(" 460 lv. is a minimum salary");
                }
                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            decimal salaryIncreace = Salary * percentage / 100;

            if (this.Age < 30)
            {
                salaryIncreace *= 0.5m;
            }

            this.Salary += salaryIncreace;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} gets {this.Salary:f2} leva.";
        }
    }
}
