using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {
        private readonly IBreakfastRepo _breakfastRepo;
        public BreakfastController(IBreakfastRepo breakfastRepo)
        {
            _breakfastRepo = breakfastRepo;
        }
        [HttpGet("GetBreakfastProducts")]
        public async Task<ActionResult<List<Breakfast>>> Get()
        {
            var respond = await _breakfastRepo.GetBreakfastProducts();
            return Ok(respond);

        }
        [HttpPost("MakeNewBreakfastProduct")]
        public async Task<ActionResult<List<Breakfast>>> Post(Breakfast breakfast)
        {

            var userid = await _breakfastRepo.GetBrakefastDB(breakfast.Id);
            if (userid == null)
            {
                _breakfastRepo.SaveBreakfastProduct(breakfast);
                return Ok("New record created successfully!");
            }
            else
                return BadRequest("Doublicate enterance!(Check id)");

        }
    }
}
