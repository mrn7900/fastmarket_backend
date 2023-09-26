using fastmarket_backend.DataProvide;

namespace fastmarket_backend.Repos
{
    public interface IBreakfastRepo
    {
        public Task<List<Breakfast>> GetBreakfastProducts();
        public void SaveBreakfastProduct(Breakfast breakfast);
        public Task<Breakfast> GetBrakefastDB(int id);
    }
}
