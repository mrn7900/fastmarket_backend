using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Repos
{
    public class DairyRepo : IDairyRepo
    {
        private readonly fastmarketContext _fastmarketContext;
        public DairyRepo(fastmarketContext fastmarketContext)
        {
            _fastmarketContext = fastmarketContext;
        }

        public string Exception { get; private set; }

        public async Task<List<Dairy>> GetDairyProducts()
        {
            return await _fastmarketContext.Dairies.ToListAsync();
        }

        public async void SaveDairyProduct(Dairy dairy)
        {
            try
            {
                _fastmarketContext.Dairies.Add(dairy);
                await _fastmarketContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                Exception = ex.Message;
            }
        }
        public async Task<Dairy> GetDairyDB(int id)
        {
            //get by id 
            var show = await _fastmarketContext.Dairies.FindAsync(id);
            return show;
        }
    }
}
