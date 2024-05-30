using MicroservicesDemo.Models;

namespace MicroservicesDemo.Repository
{
    public interface ICategoryRepo
    {
        public IEnumerable<CategoryDetails> GetCategories();
        public void InsertCategory(CategoryDetails category);
        public void UpdateCategory(CategoryDetails category);
        public CategoryDetails GetCategory(int id);
        public void DeleteCategory(int id);
    }
}
