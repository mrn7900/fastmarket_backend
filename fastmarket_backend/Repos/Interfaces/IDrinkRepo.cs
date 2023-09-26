using fastmarket_backend.DataProvide;

namespace fastmarket_backend.Repos.Interfaces
{
    public interface IDrinkRepo
    {
        public Task<List<Drink>> GetDrinkProducts();
        public void SaveDrinkProduct(Drink drink);
        public Task<Drink> GetDrinkDB(int id);
    }
}
