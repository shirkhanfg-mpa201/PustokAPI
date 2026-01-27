using AutoMapper;
using Pustok.Business.Dtos.ProductDtos;
using Pustok.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Profiles
{
    internal class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductGetDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

        }

    }
}
