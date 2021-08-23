using System;

namespace CustomValidator
{
    public class Program
    {
        public static void Main()
        {
            Cat cat = new Cat 
            { 
                Name = "John",
                Age = 2,
                Color = "Black"
            };

            Cat cat1 = new Cat
            {
                Name = "J",
                Age = 0,
                Color = "Yellow"
            };

            ObjecValidator validator = new ObjecValidator();          

            var result = validator.Validator(cat);

            PrintErrors(result);

            var result1 = validator.Validator(cat1);

            PrintErrors(result1);
        }

        private static void PrintErrors(ValidationResult result)
        {
            Console.WriteLine(result.IsValid ? "Valid" : "Invalid");

            foreach (var (key, value) in result.Errors)
            {
                Console.WriteLine(key);

                foreach (var errorMessege in value)
                {
                    Console.WriteLine($"---{errorMessege}");
                }

                Console.WriteLine("-------------------");
            }
        }
    }
}
