using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos;
using fastmarket_backend.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriedfruitRepoController : ControllerBase
    {
        private readonly IDriedfruitRepo _driedfruitRepo;
        public DriedfruitRepoController(IDriedfruitRepo driedfruitRepo)
        {
            _driedfruitRepo = driedfruitRepo;
        }
        [HttpGet("GetDriedfruitRepo")]
        public async Task<ActionResult<List<Driedfruit>>> Get()
        {
            var respond = await _driedfruitRepo.GetDriedfruitProducts();
            return Ok(respond);

        }
        [HttpPost("MakeNewDriedfruitRepo")]
        public async Task<ActionResult<List<Driedfruit>>> Post(Driedfruit driedfruit)
        {

            var userid = await _driedfruitRepo.GetDriedfruitDB(driedfruit.Id);
            if (userid == null)
            {
                _driedfruitRepo.SaveDriedfruitProduct(driedfruit);
                return Ok("New record created successfully!");
            }
            else
                return BadRequest("Doublicate enterance!(Check id)");

        }
    }
}
