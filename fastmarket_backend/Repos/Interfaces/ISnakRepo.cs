using fastmarket_backend.DataProvide;

namespace fastmarket_backend.Repos.Interfaces
{
    public interface ISnakRepo
    {
        public Task<List<Snak>> GetSnakProducts();
        public void SaveSnakProduct(Snak snak);
        public Task<Snak> GetSnakDB(int id);
    }
}
