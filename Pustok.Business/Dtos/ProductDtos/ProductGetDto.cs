namespace Pustok.Business.Dtos.ProductDtos
{
    public class ProductGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
