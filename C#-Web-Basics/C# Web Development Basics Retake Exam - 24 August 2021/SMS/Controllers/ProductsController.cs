using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Data.Models;
using SMS.Service;
using SMS.Views.Products;
using System.Linq;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IValidatorService validator;
        private readonly IDataHelper helper;

        public ProductsController(SMSDbContext data,
            IValidatorService validator,
            IDataHelper helper)
        {
            this.data = data;
            this.validator = validator;
            this.helper = helper;
        }

        [Authorize]
        public HttpResponse Create()
            => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(ProductFormModel model)
        {
            var errors = validator.ProductValidator(model);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            var product = helper.GetProducts(model);

            this.data.Products.Add(product);

            this.data.SaveChanges();

            return this.Redirect("/");
        }       
    }
}
