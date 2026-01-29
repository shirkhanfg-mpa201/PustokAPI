using Microsoft.AspNetCore.Http;

namespace Pustok.Business.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IFormFile? Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
    }
}
