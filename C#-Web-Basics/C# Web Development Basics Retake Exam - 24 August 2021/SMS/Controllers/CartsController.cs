using Microsoft.EntityFrameworkCore;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Data.Models;
using SMS.Service;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IValidatorService validator;
        private readonly IDataHelper helper;
        private readonly IPasswordHasher passwordHasher;

        public CartsController(SMSDbContext data,
            IValidatorService validator,
            IDataHelper helper,
            IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.validator = validator;
            this.helper = helper;
            this.passwordHasher = passwordHasher;
        }

        [Authorize]
        public HttpResponse Details()
        {
            var user = helper.GetUserById(User.Id);

            var productst = helper.GetPdoducts(user.CartId);

            return this.View(productst);
        }


        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            var user = helper.GetUserById(User.Id);

            var userCart = helper.GetCartById(user.CartId);

            var product = helper.GetProductById(productId);

            if (userCart == null || product == null)
            {
                return BadRequest();
            }

            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                CartId = user.CartId,
            };

            this.data.Products.Add(newProduct);

            this.data.SaveChanges();

            return Redirect("/Carts/Details");
        }

        [Authorize]
        public HttpResponse Buy()
        {
            var user = helper.GetUserById(User.Id);

            var userCart = helper.GetCartById(user.CartId);

            var products = helper.GetPdoducts(userCart.Id);

            this.data.RemoveRange(products);

            this.data.SaveChanges();

            return this.Redirect("/");
        }
    }
}
