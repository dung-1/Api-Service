﻿using Api_Service.DTOs;
using Api_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api_Service.Controllers
{

    [Authorize(Roles = "User")]

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
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] ProductDto productDto)
        {
            if (id != productDto.Id) return BadRequest();

            IFormFile imageFile = null;
            if (Request.Form.Files.Count > 0)
            {
                imageFile = Request.Form.Files[0];
            }

            try
            {
                var updatedProduct = await _productService.UpdateAsync(productDto, imageFile);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }

}
