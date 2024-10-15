using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Api_Service.Model
{
    public class Category : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> Subcategories { get; set; } = new List<Category>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}