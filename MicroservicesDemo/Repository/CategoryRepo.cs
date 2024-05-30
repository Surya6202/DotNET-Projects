using MicroservicesDemo.Models;

namespace MicroservicesDemo.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        CategoryContext _context;
        public CategoryRepo(CategoryContext context)
        {
            this._context = context;
        }
        public IEnumerable<CategoryDetails> GetCategories()
        {
            try
            {
                return _context.Categories.ToList();
            }
            catch
            {
                return null;
            }
        }

        public CategoryDetails GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public void InsertCategory(CategoryDetails category)
        {
            if (category != null)
            {
                _context.Add(category);
                _context.SaveChanges();
            }

        }


        public void UpdateCategory(CategoryDetails category)
        {
            CategoryDetails temp = _context.Categories.Find(category.CategoryId);
            if (temp != null)
            {
                temp.CategoryId = category.CategoryId;
                temp.CategoryName = category.CategoryName;
                _context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            var temp = _context.Categories.Find(id);
            _context.Categories.Remove(temp);
            _context.SaveChanges();
        }
    }
}
