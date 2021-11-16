using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DataTransferObject;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //var salesJson = File.ReadAllText("../../../Datasets/sales.json");

            //ImportSuppliers(db, suppliersJson);
            //ImportParts(db, partsJson);
            //ImportCars(db, carsJson);
            //ImportCustomers(db, customersJson);

            var result = GetSalesWithAppliedDiscount(db);

           Console.WriteLine(result);
        }        

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = (x.Discount).ToString("f2"),
                    price = (x.Car.PartCars.Sum(y => y.Part.Price)).ToString("f2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) -
                                        (x.Car.PartCars.Sum(y => y.Part.Price) * (x.Discount) / 100)).ToString("f2"),
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count() > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count(),
                    spentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(c => c.Part.Price))                    
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context) 
        {
            var cars = context.Cars
                .Select(x => new 
                {
                    car = new  
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },                    
                    parts = x.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2"),
                    })
                    .ToList()
                })
                .ToList();

            var jsonSetings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.SerializeObject(cars, jsonSetings);
        }       

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Where(p => p.Supplier.IsImporter).Count()
                })                
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new 
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customer = context.Customers
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .OrderBy(x => x.BirthDate).ThenBy(x => x.IsYoungDriver)
                .ToList();

            var jsonSetings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "dd/MM/yyyy"
            };

            return JsonConvert.SerializeObject(customer, jsonSetings);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitliazeAutoMapper();

            var salseDto = JsonConvert.DeserializeObject<IEnumerable<SalesInputModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(salseDto);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitliazeAutoMapper();

            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustumerInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);
                        
            var listCars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currCar.PartCars.Add(new PartCar
                    {
                        PartId = partId,
                    });
                }

                listCars.Add(currCar);
            }
            ;

            context.Cars.AddRange(listCars);

            context.SaveChanges();

            return $"Successfully imported {listCars.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitliazeAutoMapper();



            var partsDto = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson);
     
            var parts = mapper.Map<IEnumerable<Part>>(partsDto).Where(x => x.SupplierId <= context.Suppliers.Count());
            
            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitliazeAutoMapper();

            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);          

            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static void InitliazeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }
    
    }
}