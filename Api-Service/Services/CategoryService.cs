using Api_Service.DTOs;
using Api_Service.Model;
using Api_Service.Repository;
using AutoMapper;

namespace Api_Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var createdCategory = await _categoryRepository.AddAsync(category);
            return _mapper.Map<CategoryDto>(createdCategory);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.ModifiedTime = DateTime.UtcNow;
            var updatedCategory = await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryDto>(updatedCategory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }
    }
}
