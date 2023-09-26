using fastmarket_backend.DataProvide;

namespace fastmarket_backend.Repos.Interfaces
{
    public interface IDairyRepo
    {
        public Task<List<Dairy>> GetDairyProducts();
        public void SaveDairyProduct(Dairy dairy);
        public Task<Dairy> GetDairyDB(int id);
    }
}
