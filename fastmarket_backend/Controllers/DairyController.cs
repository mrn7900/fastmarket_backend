using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fastmarket_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DairyController : ControllerBase
    {
        private readonly IDairyRepo _dairyRepo;
        public DairyController(IDairyRepo dairyRepo)
        {
            _dairyRepo = dairyRepo;
        }
        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<Dairy>>> Get()
        {
            var respond = await _dairyRepo.GetDairyProducts();
            return Ok(respond);

        }
        [HttpPost("MakeNewCategory")]
        public async Task<ActionResult<List<Dairy>>> Post(Dairy dairy)
        {

            var userid = await _dairyRepo.GetDairyDB(dairy.Id);
            if (userid == null)
            {
                _dairyRepo.SaveDairyProduct(dairy);
                return Ok("New record created successfully!");
            }
            else
                return BadRequest("Doublicate enterance!(Check id)");

        }
    }
}
