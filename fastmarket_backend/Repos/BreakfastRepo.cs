using fastmarket_backend.DataProvide;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Repos
{
    public class BreakfastRepo : IBreakfastRepo
    {
        private readonly fastmarketContext _fastmarketContext;
        public BreakfastRepo(fastmarketContext fastmarketContext)
        {
            _fastmarketContext = fastmarketContext;
        }

        public string Exception { get; private set; }

        public async Task<List<Breakfast>> GetBreakfastProducts()
        {
            return await _fastmarketContext.Breakfasts.ToListAsync();
        }

        public async void SaveBreakfastProduct(Breakfast breakfast)
        {
            try
            {
                _fastmarketContext.Breakfasts.Add(breakfast);
                await _fastmarketContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                Exception = ex.Message;
            }
        }
        public async Task<Breakfast> GetBrakefastDB(int id)
        {
            //get by id 
            var show = await _fastmarketContext.Breakfasts.FindAsync(id);
            return show;
        }
    }
}
