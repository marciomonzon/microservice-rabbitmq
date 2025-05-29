using EDA_Inventory.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EDA_Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _productDbContext;

        public ProductController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        [HttpGet]
        [Route("/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _productDbContext.Products.ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            _productDbContext.Products.Update(product);

            await _productDbContext.SaveChangesAsync();

            var productSerialized = JsonConvert.SerializeObject(new
            {
                product.Id,
                NewName = product.Name,
                product.Quantity
            });

            return CreatedAtAction("GetProducts", new { product.Id }, product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            await _productDbContext.SaveChangesAsync();

            var productSerialized = JsonConvert.SerializeObject(new
            {
                product.Id,
                product.ProductId,
                product.Name,
                product.Quantity
            });

            return CreatedAtAction("GetProducts", new { product.Id }, product);
        }
    }
}
