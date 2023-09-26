using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Repos
{
    public class DriedfruitRepo: IDriedfruitRepo
    {
        private readonly fastmarketContext _fastmarketContext;
        public DriedfruitRepo(fastmarketContext fastmarketContext)
        {
            _fastmarketContext = fastmarketContext;
        }

        public string Exception { get; private set; }

        public async Task<List<Driedfruit>> GetDriedfruitProducts()
        {
            return await _fastmarketContext.Driedfruits.ToListAsync();
        }

        public async void SaveDriedfruitProduct(Driedfruit driedfruit)
        {
            try
            {
                _fastmarketContext.Driedfruits.Add(driedfruit);
                await _fastmarketContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                Exception = ex.Message;
            }
        }
        public async Task<Driedfruit> GetDriedfruitDB(int id)
        {
            //get by id 
            var show = await _fastmarketContext.Driedfruits.FindAsync(id);
            return show;
        }
    }
}
