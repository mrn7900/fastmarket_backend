using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fastmarket_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkRepo _drinkRepo;
        public DrinkController(IDrinkRepo drinkRepo)
        {
            _drinkRepo = drinkRepo;
        }
        [HttpGet("GetDriedfruitRepo")]
        public async Task<ActionResult<List<Drink>>> Get()
        {
            var respond = await _drinkRepo.GetDrinkProducts();
            return Ok(respond);

        }
        [HttpPost("MakeNewDriedfruitRepo")]
        public async Task<ActionResult<List<Drink>>> Post(Drink drink)
        {

            var userid = await _drinkRepo.GetDrinkDB(drink.Id);
            if (userid == null)
            {
                _drinkRepo.SaveDrinkProduct(drink);
                return Ok("New record created successfully!");
            }
            else
                return BadRequest("Doublicate enterance!(Check id)");

        }
    }
}
