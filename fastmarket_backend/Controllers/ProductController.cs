using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fastmarket_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var respond = await _productRepo.GetProducts();
            return Ok(respond);

        }
        [HttpPost("MakeNewProduct")]
        public async Task<ActionResult<List<Product>>> Post(Product product)
        {

            var userid = await _productRepo.GetProductsDB(product.Id);
            if (userid == null)
            {
                _productRepo.SaveProduct(product);
                return Ok("New record created successfully!");
            }
            else
                return BadRequest("Doublicate enterance!(Check id)");

        }
    }
}
