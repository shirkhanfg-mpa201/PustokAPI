using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pustok.Business.Dtos.ProductDtos;
using Pustok.Business.Services.Abstractions;

namespace Product.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _service) : ControllerBase
    {

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Created");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted");
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var product = await _service.GetAsync(id);
            return Ok(product);
        }
    }
}
