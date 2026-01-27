using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.Business.Dtos.ProductDtos;
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
    internal class ProductService(IProductRepository _repository, IMapper _mapper) : IProductService
    {
        public async Task CreateAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product =await _repository.GetByIdAsync(id);

            if (product is null) throw new NotFoundException("Product not found");

            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<ProductGetDto>> GetAllAsync()
        {
            var products =await _repository.GetAll().Include(x=> x.Category).ToListAsync();

            var dtos = _mapper.Map<List<ProductGetDto>>(products);

            return dtos;
        }

        public async Task<ProductGetDto> GetAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product is null) throw new NotFoundException("Product not found");

            var dto = _mapper.Map<ProductGetDto>(product);

            return dto;

        }


        public async Task UpdateAsync(ProductUpdateDto dto)
        {
            var product = await _repository.GetByIdAsync(dto.Id);

            if (product is null)
                throw new NotFoundException("Product not found");

            product = _mapper.Map(dto, product);

            _repository.Update(product);
            await _repository.SaveChangesAsync();
        }
    }
}
