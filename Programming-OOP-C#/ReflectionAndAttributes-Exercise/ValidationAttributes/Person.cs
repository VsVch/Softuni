
using System.ComponentModel.DataAnnotations;


namespace ValidationAttributes
{
    public class Person
    {
        private const int minAge = 12;
        private const int maxAge = 90;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        [MyRequired]
        public string Name { get; private set; }
        [MyRange(minAge, maxAge)]
        public int Age { get;private set; }
    }
}
