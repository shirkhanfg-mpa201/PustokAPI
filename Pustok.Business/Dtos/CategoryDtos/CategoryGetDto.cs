using Pustok.Business.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.CategoryDtos
{
    public class CategoryGetDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<ProductGetDto> Products { get; set; } = [];
    }
}
