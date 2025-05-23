﻿using Api_Service.Model;

namespace Api_Service.DTOs
{
    public class ProductDto : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
