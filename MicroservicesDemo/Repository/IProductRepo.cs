using MicroservicesDemo.Models;

namespace MicroservicesDemo.Repository
{
    public interface IProductRepo
    {
        public void InsertProduct(ProductDetails product);
        public IEnumerable<ProductDetails> GetProducts();
        public ProductDetails GetProduct(int id);
        public void UpdateProduct(ProductDetails product);
        public void DeleteProduct(int id);
    }
}
