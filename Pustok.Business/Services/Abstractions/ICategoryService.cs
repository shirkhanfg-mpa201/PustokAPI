using Pustok.Business.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto dto);

        Task UpdateAsync(CategoryUpdateDto dto);

        Task DeleteAsync(Guid id);

        Task<List<CategoryGetDto>> GetAllAsync();

        Task<CategoryGetDto> GetByIdAsync(Guid id);
    }
}
