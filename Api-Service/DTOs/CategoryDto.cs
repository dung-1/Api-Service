using Api_Service.Model;

namespace Api_Service.DTOs
{
    public class CategoryDto : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
