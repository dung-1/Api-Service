using System.ComponentModel.DataAnnotations;

namespace Api_Service.Model
{
    public class Post : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? ExcerptImage { get; set; }
        public int? ViewCount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
