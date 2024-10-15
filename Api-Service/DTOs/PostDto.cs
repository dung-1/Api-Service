using Api_Service.Model;

namespace Api_Service.DTOs
{
    public class PostDto : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? ExcerptImage { get; set; }
        public int? ViewCount { get; set; }
        public int CategoryId { get; set; }
    }
}
