using Api_Service.Common;
using Api_Service.DTOs;
using Api_Service.Model;
using Api_Service.Repository;
using AutoMapper;

namespace Api_Service.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public PostService(IPostRepository postRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _env = env;
        }
        
        public async Task<IEnumerable<PostDto>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> AddAsync(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post = await _postRepository.AddAsync(post);
            return _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> UpdateAsync(PostDto postDto, IFormFile imageFile)
        {
            var existingPost = await _postRepository.GetByIdAsync(postDto.Id);
            if (existingPost == null)
            {
                throw new NotFoundException("Post not found");
            }

            if (imageFile != null)
            {
                var imagePath = await SaveImageAsync(imageFile);
                postDto.ExcerptImage = imagePath;
            }
            else
            {
                // Giữ nguyên ảnh cũ nếu không có ảnh mới được tải lên
                postDto.ExcerptImage = existingPost.ExcerptImage;
            }

            var post = _mapper.Map(postDto, existingPost);
            post.ModifiedTime = DateTime.UtcNow;
            post = await _postRepository.UpdateAsync(post);
            return _mapper.Map<PostDto>(post);
        }



        public async Task<bool> DeleteAsync(int id)
        {
            return await _postRepository.DeleteAsync(id);
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
