using SMS.Data;
using SMS.Data.Models;
using SMS.ViewModels.Carts;
using SMS.ViewModels.Products;
using SMS.Views.Products;

using System.Collections.Generic;
using System.Linq;

namespace SMS.Service
{ 
    public class DataHelper : IDataHelper
    {
        private readonly SMSDbContext data;

        public DataHelper(SMSDbContext data)
        {
            this.data = data;
        }

        public Cart GetCartById(string id)
            => this.data.Carts.Find(id);

        public List<DetailsProductModel> GetPdoductsModel(string cardId)
        {
            return this.data
                .Products
                .Where(p => p.CartId == cardId)
                .Select(p => new DetailsProductModel
                {
                    Name = p.Name,
                    Price = p.Price.ToString("f2")
                })
                .ToList();
        }

        public List<Product> GetPdoducts(string cardId)
        {
            return this.data
                .Products
                .Where(p => p.CartId == cardId)                
                .ToList();
        }

        public Product GetProductByCartId(string cartId)
         => this.data.Products.FirstOrDefault(p => p.CartId == cartId);

        public Product GetProductById(string id)
            => this.data.Products.FirstOrDefault(p => p.Id == id);
            

        public Product GetProducts(ProductFormModel model)
            => new Product
            {
                Name = model.Name,
                Price = model.Price,
                CartId = null,
            };

        public User GetUserById(string id)
            => this.data.Users
                  .Where(u => u.Id == id)
                  .FirstOrDefault();

        public UserProductsModel GetUserProductsData(string username)
        {
            var products = new UserProductsModel
            {
                Name = username,
                Products = this.data.Products
               .Where(p => p.CartId == null)
               .Select(p => new AllProductsModel
               {
                   Name = p.Name,
                   Id = p.Id,
                   Price = p.Price,
               })               
               .ToList()
            };

            return products;
        }        
    }
}
