using fastmarket_backend.DataProvide;

namespace fastmarket_backend.Repos.Interfaces
{
    public interface IDriedfruitRepo
    {
        public Task<List<Driedfruit>> GetDriedfruitProducts();
        public void SaveDriedfruitProduct(Driedfruit driedfruit);
        public Task<Driedfruit> GetDriedfruitDB(int id);
    }
}
