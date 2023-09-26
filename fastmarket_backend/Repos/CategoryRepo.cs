using fastmarket_backend.DataProvide;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly fastmarketContext _fastmarketContext;
        public CategoryRepo(fastmarketContext fastmarketContext)
        {
            _fastmarketContext = fastmarketContext;
        }

        public string Exception { get; private set; }

        public async Task<List<Category>> GetCategoryProducts()
        {
            return await _fastmarketContext.Categories.ToListAsync();
        }

        public async void SaveCategoryProduct(Category category)
        {
            try
            {
                _fastmarketContext.Categories.Add(category);
                await _fastmarketContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                Exception = ex.Message;
            }
        }
        public async Task<Category> GetCategoryDB(int id)
        {
            //get by id 
            var show = await _fastmarketContext.Categories.FindAsync(id);
            return show;
        }
    }
}
