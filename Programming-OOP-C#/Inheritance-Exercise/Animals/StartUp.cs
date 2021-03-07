using System;
namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;

            Animal animal = null;

            while ((input = Console.ReadLine()) != "Beast!")
            {                
                string[] rowDate = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);                

                try
                {
                    string name = rowDate[0];
                    int age = int.Parse(rowDate[1]);
                    string gender = rowDate[2];                    

                    if (input == nameof(Cat))
                    {
                        animal = new Cat(name, age, gender);                    
                    }
                    else if (input == nameof(Dog))
                    {
                        animal = new Dog(name, age, gender);                        
                    }
                    else if (input == nameof(Frog))
                    {
                        animal = new Frog(name, age, gender);                        
                    }
                    else if (input == nameof(Kitten))
                    {
                        animal = new Kitten(name, age);                        
                    }
                    else if (input == nameof(Tomcat))
                    {
                        animal = new Tomcat(name, age);                        
                    }
                    Console.WriteLine(input);
                    Console.WriteLine(animal.ToString());
                    Console.WriteLine(animal.ProduceSound());
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                   
                   
                }       
           
            }
        }
    }
}
