using MicroservicesDemo.Models;
using MicroservicesDemo.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroservicesDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo productRepo;

        public ProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        [HttpGet]
        public IEnumerable<ProductDetails> Get()
        {
            return productRepo.GetProducts();
        }

        [HttpPost]
        public void Post([FromBody] ProductDetails product)
        {
            productRepo.InsertProduct(product);
        }

        [HttpGet("{id}")]
        public ProductDetails Get(int id)
        {
            return productRepo.GetProduct(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDetails product)
        {
            productRepo.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productRepo.DeleteProduct(id);
        }
    }
}
