using Pustok.Business.Dtos.CategoryDtos;
using Pustok.Business.Dtos.ResultDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ResultDto> CreateAsync(CategoryCreateDto dto);

        Task<ResultDto> UpdateAsync(CategoryUpdateDto dto);

        Task<ResultDto> DeleteAsync(Guid id);

        Task<ResultDto<List<CategoryGetDto>>> GetAllAsync();

        Task<ResultDto<CategoryGetDto>> GetByIdAsync(Guid id);
    }
}
