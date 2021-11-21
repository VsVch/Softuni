using CarDealer.Data;
using CarDealer.DataTransferObject.Input;
using CarDealer.DataTransferObject.Output;
using CarDealer.Models;
using CarDealer.Models.XmlHelper;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            //var partsXml = File.ReadAllText("./Datasets/parts.xml");
            //var carsXml = File.ReadAllText("./Datasets/cars.xml");
            //var customersXml = File.ReadAllText("./Datasets/customers.xml");
            //var salesXml = File.ReadAllText("./Datasets/sales.xml");

            //ImportSuppliers(db, supplierXml);
            //ImportParts(db, partsXml);
            //ImportCars(db, carsXml);
            //ImportCustomers(db, customersXml);
            //ImportSales(db, salesXml)

            var result = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(result);
        }
        
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new SaleOutputModel
                {
                    
                    Car = new CarOutputAtributsModel
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWhitDiscount = x.Car.PartCars.Sum(p => p.Part.Price) -
                                       (x.Car.PartCars.Sum(p => p.Part.Price) *
                                        x.Discount / 100)
                })
                .ToList();

            var result = XmlConverter.Serialize(sales, "sales");

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count() > 0)
                .Select(x => new CustomerOutputModel
                {
                    FullName = x.Name,
                    CarCount = x.Sales.Count(),
                    TotallMoneySpend = x.Sales.Select(x => x.Car)
                                              .SelectMany(x => x.PartCars)
                                              .Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.TotallMoneySpend)
                .ToList();

            var result = XmlConverter.Serialize(customers, "customers");

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.
                Select(X => new CarWhitPartsOutputModel
                {
                    Make = X.Make,
                    Model = X.Model,
                    TravelledDistance = X.TravelledDistance,
                    PartOutputModel = X.PartCars.Select(y => new PartOutputModel
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price
                    })
                    .OrderByDescending(y => y.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();
                     
            var converter = XmlConverter.Serialize(cars, "cars");

            return converter;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new SuppliersOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountParts = x.Parts.Count()
                })
                .ToArray();

            var textWriter = new StringWriter();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SuppliersOutputModel[]),
                new XmlRootAttribute("suppliers"));
                        
            var sn = XmlNamespacesCleaner();

            xmlSerializer.Serialize(textWriter, suppliers, sn);            

            return textWriter.ToString();
        }                

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsBMW = context.Cars
                 .Where(x => x.Make == "BMW")
                 .Select(x => new CarBMWOutputModel
                 {
                     Id = x.Id,
                     Model = x.Model,
                     TravelledDistance = x.TravelledDistance
                 })
                 .OrderBy(x => x.Model)
                 .ThenByDescending(x => x.TravelledDistance)
                 .ToArray();

            var textWriter = new StringWriter();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarBMWOutputModel[]),
                new XmlRootAttribute("cars"));

            var sn = XmlNamespacesCleaner();

            xmlSerializer.Serialize(textWriter, carsBMW, sn);

            return textWriter.ToString();
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {                    
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var textWriter = new StringWriter();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]),
                new XmlRootAttribute("cars"));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, ns);

            return textWriter.ToString();
        }
                
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SalesInputModel[]), 
                new XmlRootAttribute("Sales"));

            var salesDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as SalesInputModel[];

            var cars = context.Cars.Select(x => x.Id).ToList();

            var sales = salesDto
                .Where(x => cars.Contains(x.CarId))
                .Select(x => new Sale
                {
                    Discount = x.Discount,
                    CarId = x.CarId,
                    CustomerId = x.CustomerId
                })
                .ToList();

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml) 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerInputModel[]),
                new XmlRootAttribute("Customers"));

            var customersDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as CustomerInputModel[];

            var customers = customersDto
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = DateTime.Parse(x.BirthDate),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarInputModel[]),
                new XmlRootAttribute("Cars"));

            var carsDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as CarInputModel[];

            var allParts = context.Parts.Select(x => x.Id).ToList();

            var cars = carsDto
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,
                    PartCars = x.CarPartsInputModel.Select(y => y.Id)
                       .Distinct()
                       .Intersect(allParts)
                       .Select( p => new PartCar
                       {
                           PartId = p
                       })
                       .ToList()
                })
                .ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartInputModel[]),
                new XmlRootAttribute("Parts"));

            var parts = xmlSerializer.Deserialize(new StringReader(inputXml)) as PartInputModel[];

            var currPartsId = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var partsFiltered = parts
                .Where(x => currPartsId.Contains(x.SupplierId))
                .Select(x => new Part 
                { 
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();           

            context.Parts.AddRange(partsFiltered);
            context.SaveChanges();

            return $"Successfully imported {partsFiltered.Count()}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]),
                new XmlRootAttribute("Suppliers"));
            var textReader = new StringReader(inputXml);
            var suppliersDto = xmlSerializer.Deserialize(textReader) as SupplierInputModel[];

            var suppliers = suppliersDto
                .Select(x => new Supplier
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter
                });

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        private static XmlSerializerNamespaces XmlNamespacesCleaner()
        {
            var sn = new XmlSerializerNamespaces();
            sn.Add("", "");

            return sn;
        }
    }
}