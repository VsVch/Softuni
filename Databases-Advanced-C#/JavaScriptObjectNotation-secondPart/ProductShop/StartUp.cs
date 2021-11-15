using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp 
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //string jsonUsers = File.ReadAllText("../../../Datasets/users.json");
            //string jsonProducts = File.ReadAllText("../../../Datasets/products.json");
            //string jsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            //string jsonCategoriesProjects = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportUsers(db, jsonUsers);
            //ImportProducts(db, jsonProducts);
            //ImportCategories(db, jsonCategories);
            //ImportCategoryProducts(db, jsonCategoriesProjects);

            var result = GetUsersWithProducts(db);

            Console.WriteLine(result);
        }

//Get all users who have at least 1 sold product with a buyer.
//Order them in descending order by the number of sold products with a buyer.
//Select only their first and last name, age and for each product - name and price.
//Ignore all null values.

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))                
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(z => z.BuyerId != null).Count(),
                        products = x.ProductsSold
                        .Where(z => z.BuyerId != null)
                        .Select(e => new
                        {
                            name = e.Name,
                            price = e.Price
                        })
                       .Where(c => c.name != null)
                       .ToList()
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();
                

            var obj = new
            {
                usersCount = context.Users.Where(x => x.ProductsSold.Any(p => p.BuyerId != null)).Count(),
                users = users
            };

            var setings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, Formatting.Indented, setings);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var category = context.Categories
            .Select(x => new
            {
                category = x.Name,
                productsCount = x.CategoryProducts.Count(),
                averagePrice = x.CategoryProducts.Count() == 0 ?
                                0.ToString("f2") : 
                                x.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                totalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("f2")
            })
            .OrderByDescending(x => x.productsCount)
            .ToList();
           
            var result = JsonConvert.SerializeObject(category, Formatting.Indented);

            return result;
        }


        public static string GetSoldProducts(ProductShopContext context) 
        {
            var user = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))                
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Where(p => p.BuyerId != null)
                    .Select(b => new
                    {
                        name = b.Name,
                        price = b.Price,
                        buyerFirstName = b.Buyer.FirstName,
                        buyerLastName = b.Buyer.LastName
                    })
                    .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(user, Formatting.Indented);

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context) 
        {
            var allProducts = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var result = JsonConvert.SerializeObject(allProducts, settings);
            //var result = JsonConvert.SerializeObject(allProducts, Formatting.Indented);

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitliazeAutoMapper();

            var categoriesProductsDto = JsonConvert.DeserializeObject<IEnumerable<CategoryProduct>>(inputJson);

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesProductsDto);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson) 
        {
            InitliazeAutoMapper();            
            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null);

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories)                ;

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitliazeAutoMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductUnputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            
            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            InitliazeAutoMapper();
            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static void InitliazeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}