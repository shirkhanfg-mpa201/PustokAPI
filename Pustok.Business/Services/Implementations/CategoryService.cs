using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.Business.Dtos.CategoryDtos;
using Pustok.Business.Exceptions;
using Pustok.Business.Services.Abstractions;
using Pustok.Core.Entities;
using Pustok.DataAccess.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Implementations
{
    internal class CategoryService(ICategoryRepository _repository, IMapper _mapper) : ICategoryService
    {
        public async Task CreateAsync(CategoryCreateDto dto)
        {
            var isExistCategory = await _repository.AnyAsync(x => x.Name == dto.Name);

            if (isExistCategory)
                throw new AlreadyExistException();

            var category = _mapper.Map<Category>(dto);

            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
            var category =await  _repository.GetAsync(x=>x.Id==id);

            if (category == null)
                throw new NotFoundException("Category not found");

            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<CategoryGetDto>> GetAllAsync()
        {
            var categories =await  _repository.GetAll().Include(x=>x.Products).ToListAsync();
            var categoryDtos = _mapper.Map<List<CategoryGetDto>>(categories);
            return categoryDtos;
        }

        public async Task<CategoryGetDto> GetByIdAsync(Guid id)
        {
            var category = await _repository.GetAsync(x=>x.Id==id);

            if (category == null)
                throw new NotFoundException("Category not found");

            var categoryDto = _mapper.Map<CategoryGetDto>(category);

            return categoryDto;

        }

        public async Task UpdateAsync(CategoryUpdateDto dto)
        {
            var category = await _repository.GetByIdAsync(dto.Id);

            if (category is null)
                throw new NotFoundException();

            var isExistCategory = await _repository.AnyAsync(x => x.Name == dto.Name && x.Id != dto.Id);

            if (isExistCategory)
                throw new AlreadyExistException();

            category = _mapper.Map(dto, category);

            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }
    }
}
