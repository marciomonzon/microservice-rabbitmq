using EDA_Customer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDA_Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerController(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        [HttpGet]
        [Route("/customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _customerDbContext.Customers.ToListAsync();
        }

        [HttpGet]
        [Route("/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _customerDbContext.Products.ToListAsync();
        }

        [HttpPost]
        public async Task PostCostumer(Customer customer)
        {
            _customerDbContext.Customers.Add(customer);
            await _customerDbContext.SaveChangesAsync();
        }
    }
}
