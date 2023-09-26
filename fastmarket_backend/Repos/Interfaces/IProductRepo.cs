using fastmarket_backend.DataProvide;

namespace fastmarket_backend.Repos
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetProducts();
        public void SaveProduct(Product product);
        public Task<Product> GetProductsDB(int id);
    }
}
