
using ASP.netCoreTreningApp.Controllers;
using ASP.netCoreTreningApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ASP.netCoreTreningApp.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void GetProductShouldReturnTheProductIfFound()
        {

            var product = new Product
            {
                Id = 1,
                Name = "produc test",
                Price = 100,
                Description = "test test test"
            };

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("Test");

            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var contorler = new ProductsController(dbContext);

            var result = contorler.Get(1);

            Assert.NotNull(result);
            Assert.Equal("produc test", result.Value.Name);
        }

        [Fact]
        public void GetProductShouldReturnNotFoundIfProductDoesnotExsist()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("Test");

            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var contorler = new ProductsController(dbContext);

            var result = contorler.Get(3);

            Assert.Null(result.Value);
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
