using MicroservicesDemo.Models;

namespace MicroservicesDemo.Repository
{
    public class ProductRepo : IProductRepo
    {
        ProductContext _context;

        public ProductRepo(ProductContext context)
        {
            this._context = context;
        }

        public IEnumerable<ProductDetails> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void InsertProduct(ProductDetails product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public ProductDetails GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public void UpdateProduct(ProductDetails product)
        {
            ProductDetails temp = _context.Products.Find(product.ProductId);
            if (temp != null)
            {
                temp.ProductId = product.ProductId;
                temp.ProductName = product.ProductName;
                temp.CategoryId = product.CategoryId;
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            _context.SaveChanges();
        }
    }
}
