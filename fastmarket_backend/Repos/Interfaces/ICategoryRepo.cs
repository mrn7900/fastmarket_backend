using fastmarket_backend.DataProvide;

namespace fastmarket_backend.Repos
{
    public interface ICategoryRepo
    {
        public Task<List<Category>> GetCategoryProducts();
        public void SaveCategoryProduct(Category category);
        public Task<Category> GetCategoryDB(int id);
    }
}
