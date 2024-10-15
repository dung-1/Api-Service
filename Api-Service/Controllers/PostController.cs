using Api_Service.DTOs;
using Api_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PostDto postDto, IFormFile imageFile)
        {
            // Nếu có hình ảnh, lưu và gán đường dẫn
            if (imageFile != null)
            {
                var imagePath = await _postService.SaveImageAsync(imageFile);
                postDto.ExcerptImage = imagePath;
            }

            // Chuyển đổi FromDate và ToDate sang UTC trước khi thêm
            postDto.FromDate = postDto.FromDate.ToUniversalTime();
            postDto.ToDate = postDto.ToDate.ToUniversalTime();

            var newPost = await _postService.AddAsync(postDto);
            return CreatedAtAction(nameof(GetById), new { id = newPost.Id }, newPost);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] PostDto postDto)
        {
            if (id != postDto.Id) return BadRequest();

            IFormFile imageFile = null;
            if (Request.Form.Files.Count > 0)
            {
                imageFile = Request.Form.Files[0];
            }

            try
            {
                var updatedPost = await _postService.UpdateAsync(postDto, imageFile);
                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the post.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }
    }

}
