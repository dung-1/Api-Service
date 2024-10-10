using Api_Service.Common;
using Api_Service.DTOs;
using Api_Service.Model;
using Api_Service.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product = await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDto, IFormFile imageFile)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productDto.Id);
            if (existingProduct == null)
            {
                throw new NotFoundException("Product not found");
            }

            if (imageFile != null)
            {
                var imagePath = await SaveImageAsync(imageFile);
                productDto.Image = imagePath;
            }
            else
            {
                // Giữ nguyên ảnh cũ nếu không có ảnh mới được tải lên
                productDto.Image = existingProduct.Image;
            }

            var product = _mapper.Map(productDto, existingProduct);
            product = await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductDto>(product);
        }



        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            var uploadDir = Path.Combine(_env.WebRootPath, "images");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            var fileName = $"{Guid.NewGuid()}_{imageFile.FileName}";
            var filePath = Path.Combine(uploadDir, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            var relativePath = $"/images/{fileName}";
            return relativePath;
        }

    }

}
