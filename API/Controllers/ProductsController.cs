using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        // endpoints
        [HttpGet]
        public async Task <ActionResult<List<Product>>> GetProducts(){ 
            // use "Task" to make it async.
            // This prevents the waiting of requests. Cuncurrent requests.
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")] // get the id from the request url
        public async Task<ActionResult<Product>> GetProduct(int id){ // access the id in the controller
            return await _repo.GetProductByIdAsync(id);
        }
    }
}