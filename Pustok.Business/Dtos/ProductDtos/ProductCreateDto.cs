using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.ProductDtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }

        public IFormFile Image { get; set; }=null!;
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
    }
}
