using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Repos
{
    public class DrinkRepo : IDrinkRepo
    {
        private readonly fastmarketContext _fastmarketContext;
        public DrinkRepo(fastmarketContext fastmarketContext)
        {
            _fastmarketContext = fastmarketContext;
        }

        public string Exception { get; private set; }

        public async Task<List<Drink>> GetDrinkProducts()
        {
            return await _fastmarketContext.Drinks.ToListAsync();
        }

        public async void SaveDrinkProduct(Drink drink)
        {
            try
            {
                _fastmarketContext.Drinks.Add(drink);
                await _fastmarketContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                Exception = ex.Message;
            }
        }
        public async Task<Drink> GetDrinkDB(int id)
        {
            //get by id 
            var show = await _fastmarketContext.Drinks.FindAsync(id);
            return show;
        }
    }
}
