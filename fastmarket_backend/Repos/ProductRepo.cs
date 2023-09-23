using fastmarket_backend.DataProvide;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly fastmarketContext _fastmarketContext;
        public ProductRepo(fastmarketContext fastmarketContext)
        {
            _fastmarketContext = fastmarketContext;
        }

        public string Exception { get; private set; }

        public async Task<List<Product>> GetProducts()
        {
            return await _fastmarketContext.Products.ToListAsync();
        }

        public async void SaveProduct(Product product)
        {     
            try
            {
                _fastmarketContext.Products.Add(product);
                await _fastmarketContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                Exception = ex.Message;
            }
        }
        public async Task<Product> GetProductsDB(int id)
        {
            //get by id 
            var show = await _fastmarketContext.Products.FindAsync(id);
            return show;
        }
    }
}
