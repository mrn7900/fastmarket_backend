using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Repos
{
    public class SnakRepo:ISnakRepo
    {
        private readonly fastmarketContext _fastmarketContext;
        public SnakRepo(fastmarketContext fastmarketContext)
        {
            _fastmarketContext = fastmarketContext;
        }

        public string Exception { get; private set; }

        public async Task<List<Snak>> GetSnakProducts()
        {
            return await _fastmarketContext.Snaks.ToListAsync();
        }

        public async void SaveSnakProduct(Snak snak)
        {
            try
            {
                _fastmarketContext.Snaks.Add(snak);
                await _fastmarketContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                Exception = ex.Message;
            }
        }
        public async Task<Snak> GetSnakDB(int id)
        {
            //get by id 
            var show = await _fastmarketContext.Snaks.FindAsync(id);
            return show;
        }
    }
}
