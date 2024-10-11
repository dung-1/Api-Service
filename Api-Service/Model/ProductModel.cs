using System.ComponentModel.DataAnnotations;

namespace Api_Service.Model
{
    public class Product : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public string? Image { get; set; }

        public Category Category { get; set; }
    }
}
