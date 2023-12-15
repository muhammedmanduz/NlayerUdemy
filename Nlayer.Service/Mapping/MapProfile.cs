using AutoMapper;
using NlayerCore.DTOs;
using NlayerCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap() ;
            CreateMap<Category, CategoryDto>().ReverseMap() ;
            CreateMap<ProductFeaure, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductasDto>();
        }

    }
}
