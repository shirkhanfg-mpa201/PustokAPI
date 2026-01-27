using Pustok.Business.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateDto dto);

        Task UpdateAsync(ProductUpdateDto dto);

        Task DeleteAsync(Guid id);

        Task<List<ProductGetDto>> GetAllAsync();

        Task<ProductGetDto> GetAsync(Guid id);

    }
}
