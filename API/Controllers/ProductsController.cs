using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;   
        }

        // endpoints
        [HttpGet]
        public async Task <ActionResult<List<Product>>> GetProducts(){ 
            // use "Task" to make it async.
            // This prevents the waiting of requests. Cuncurrent requests.
            var products = await _context.Products.ToListAsync();
            return products;
        }

        [HttpGet("{id}")] // get the id from the request url
        public async Task<ActionResult<Product>> GetProduct(int id){ // access the id in the controller
            return await _context.Products.FindAsync(id);
        }
    }
}