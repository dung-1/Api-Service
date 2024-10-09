using Api_Service.DTOs;
using Api_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductDto productDto, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var imagePath = await _productService.SaveImageAsync(imageFile);
                productDto.Image = imagePath;
            }

            var newProduct = await _productService.AddAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] ProductDto productDto, IFormFile imageFile)
        {
            if (id != productDto.Id) return BadRequest();

            var updatedProduct = await _productService.UpdateAsync(productDto, imageFile);
            return Ok(updatedProduct);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }

}
