using ASP.netCoreTreningApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.netCoreTreningApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext data;

        public ProductsController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return data.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = this.data.Products.Find(id);

            if (product == null)
            {
                return this.NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            await this.data.Products.AddAsync(product);
            await this.data.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Product product)
        {
            this.data.Entry(product).State = EntityState.Modified;
            await this.data.SaveChangesAsync();
            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = this.data.Products.Find(id);

            if (product == null)
            {
                return this.NotFound();
            }

            this.data.Remove(product);
            await this.data.SaveChangesAsync();
            return this.NoContent();
        }
    }
}
