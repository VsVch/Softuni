using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JsonDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var car = new Car
            {
                Extras = new List<string> { "Klimatic", "4x4", "Leti Djanti" },
                ManufacturedOn = DateTime.UtcNow,
                Model = "Opel",
                Vendor = "Meriva",
                Price = 20000,
                Engine = new Engine { HoresPower = 200, Volume = 1.6m }

            };
            //SystemTextJsonSerializer(car);            
            //SystemTextJsonDeserializer(car);
            //NewtonsoftJsonMainMethods(car);
            //NewtonsoftJsonAnonimusType(car);
            //LinqToJson();           
           
        }        

        private static void LinqToJson()
        {
            var json = File.ReadAllText("myCar.json");

            JObject jObject = JObject.Parse(json);

            foreach (var item in jObject.Children().Where(x =>x.Children().First().Count() > 1))
            {
                Console.WriteLine(item);
            }
        }

        private static void NewtonsoftJsonAnonimusType(Car car)
        {
            var json = File.ReadAllText("myCar.json");

            var setings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new KebabCaseNamingStrategy()
                }
            };

            var a = new
            {
                Model = " ",
                Vendor = " ",
                Price = 0.0M
            };

            Console.WriteLine(JsonConvert.DeserializeAnonymousType(json, a, setings));
        }

        private static void NewtonsoftJsonMainMethods(Car car)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(new { Name = "Sasho", Age = 39 }));
            
            var json = File.ReadAllText("myCar.json");
            var curCar =JsonConvert.DeserializeObject<Car>(json);

            var setings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new KebabCaseNamingStrategy()
                },
                DateFormatString = "yyyy-MM-dd",
            };          

            Console.WriteLine(JsonConvert.SerializeObject(new { Car = car, Name = "Sasho"}, setings));

        }

        //private static void SystemTextJsonDeserializer(Car car)
        //{
        //    var options = new JsonSerializerOptions
        //    {
        //    };

        //    var json = File.ReadAllText("myCar.json");
        //    Car curCar = JsonSerializer.Deserialize<Car>(json);
                       
        //}

        //private static void SystemTextJsonSerializer(Car car)
        //{
        //    File.WriteAllText("myCar.json",JsonSerializer.Serialize(car)); //-> seve json in file
        //    var option = new JsonSerializerOptions
        //    {
        //        WriteIndented = true,
        //    };
        //    Console.WriteLine(JsonSerializer.Serialize(car, option));
        //}
    }
}
