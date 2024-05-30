using MicroservicesDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroservicesDemo.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        [HttpGet]
        public IEnumerable<CategoryDetails> Get()
        {
            return categoryRepo.GetCategories();
        }

        [HttpPost]
        public void Post([FromBody] CategoryDetails category)
        {
            categoryRepo.InsertCategory(category);
        }

        [HttpGet("{id}")]
        public CategoryDetails Get(int id)
        {
            return categoryRepo.GetCategory(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryDetails category)
        {
            categoryRepo.UpdateCategory(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryRepo.DeleteCategory(id);
        }
    }
}
