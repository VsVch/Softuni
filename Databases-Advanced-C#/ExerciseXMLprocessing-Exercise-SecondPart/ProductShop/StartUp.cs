using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.Models.XmlHelper;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var xmlUsers = File.ReadAllText("./Datasets/users.xml");
            //var xmlProducts = File.ReadAllText("./Datasets/products.xml");
            //var xmlCategory = File.ReadAllText("./Datasets/categories.xml");
            //var xmlCategoryProducts = File.ReadAllText("./Datasets/categories-products.xml");

            //ImportUsers(db, xmlUsers);
            //ImportProducts(db, xmlProducts);
            //ImportCategories(db, xmlCategory);
            //ImportCategoryProducts(db, xmlCategoryProducts);

            var result = GetUsersWithProducts(db);

            System.Console.WriteLine(result);
        }


        //Select users who have at least 1 sold product.Order them by the number of sold products
        //(from highest to lowest). Select only their first and last name, age, count of sold products and
        //for each product - name and price sorted by price(descending). Take top 10 records.

        public static string GetUsersWithProducts(ProductShopContext context)
        {
           
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToArray()
                .Where(x => x.ProductsSold.Any())
                .OrderByDescending(x => x.ProductsSold.Count())
                .Take(10)
                .Select(y => new UsersProductsOutputModel
                {
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    Age = y.Age,
                    SoldProducts = new SoldProductsContainer
                    { 
                        Count = y.ProductsSold.Count,
                        Products = y.ProductsSold.Select(ps => new SoldProducts
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .OrderByDescending(p => p.Price).ToArray()                    
                    }
                })
                .ToArray();



            var Users = new UserDTO
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = users
            };

            var result = XmlConverter.Serialize(Users, "Users");
             
           return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var category = context.Categories                
                .Select(x => new CategoryOutputModels
                {
                    Name = x.Name,
                    ProductsCount = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts
                                                     .Average(cp => cp.Product.Price) == 0 
                                                     ? 0
                                                     : x.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.ProductsCount)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var result = XmlConverter.Serialize(category, "Categories");

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count() > 0)
                .Select(x => new UserOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProductsUsers = x.ProductsSold.Select(p => new ProductUserOutputModel
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var result = XmlConverter.Serialize(users, "Users");

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {


            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductOutputModel 
                { 
                    Name = x.Name,
                    Price = x.Price,
                    FullName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToList();


            var result = XmlConverter.Serialize(products, "Products");

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";

            var categoryIdList = context.Categories.Select(x => x.Id).ToList();
            var productIdList = context.Products.Select(x => x.Id).ToList();


            var categoryesProductsDto = XmlConverter.Deserializer<CategoryProductInputModel>(inputXml, root);

            var categoryesProducts = categoryesProductsDto
                .Where(x => categoryIdList.Contains(x.CategoryId) && productIdList.Contains(x.ProductId))
                .Select(x => new CategoryProduct 
                { 
                    ProductId = x.ProductId,
                    CategoryId = x.CategoryId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryesProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";

            var categoryDto = XmlConverter.Deserializer<CategoryInputModel>(inputXml, root);

            var category = categoryDto
                .Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToList();

            context.Categories.AddRange(category);
            context.SaveChanges();

            return $"Successfully imported {category.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {

            const string root = "Products";

            var productsDto = XmlConverter.Deserializer<ProductInputModel>(inputXml, root);

            var product = productsDto
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x.BuyerId
                })
                .ToList();

            context.Products.AddRange(product);
            context.SaveChanges();

            return $"Successfully imported {product.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string root = "Users";

            var userDto = XmlConverter.Deserializer<UserInputModel>(inputXml, root);

            var users = userDto
                .Select(x => new User
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();
             
            return $"Successfully imported {users.Count()}";
        }
    }
}