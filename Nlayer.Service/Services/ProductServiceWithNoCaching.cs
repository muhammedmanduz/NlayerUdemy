using AutoMapper;
using NlayerCore.DTOs;
using NlayerCore.Model;
using NlayerCore.Repositoies;
using NlayerCore.Services;
using NlayerCore.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Service.Services
{
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductServiceWithNoCaching(IUnitOfWork unitOfWork, IGenericRepository<Product> repository ,IMapper mapper, IProductRepository productRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var product=await _productRepository.GetProductsWithCategory(); 

            var productsDto= _mapper.Map<List<ProductWithCategoryDto>>(product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
