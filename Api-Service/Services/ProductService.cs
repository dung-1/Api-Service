using Api_Service.DTOs;
using Api_Service.Model;
using Api_Service.Repository;
using AutoMapper;

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

        public async Task<ProductDto> UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product = await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        // Thêm phương thức lưu ảnh
        //public async Task<string> SaveImageAsync(IFormFile imageFile)
        //{
        //    if (imageFile != null && imageFile.Length > 0)
        //    {
        //        var filePath = Path.Combine("wwwroot/images", imageFile.FileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await imageFile.CopyToAsync(stream);
        //        }

        //        return filePath;
        //    }

        //    return null;
        //}
        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            var uploadDir = Path.Combine(_env.WebRootPath, "images"); // Sử dụng WebRootPath để trỏ tới thư mục wwwroot
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

            // Trả về đường dẫn tương đối, bỏ 'wwwroot' ra.
            var relativePath = $"/images/{fileName}";
            return relativePath;
        }

    }

}
