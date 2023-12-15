using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nlayer.API.Filters;
using NlayerCore.DTOs;
using NlayerCore.Model;
using NlayerCore.Services;

namespace Nlayer.API.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
      
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
      
            this._service = productService;
        }

        //Get api/products/GetproductsWithCategory
        [HttpGet("GetProductWithCategory")]
        public  async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }



        //Get/api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products=await _service.GetAllAsync();
            var productsDtos= _mapper.Map<List<ProductDto>>(products.ToList());
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));

        }



        //Get/api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
          
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));

        }


        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        //Get/api/products/5
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        //Delete/api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);

             await _service.RemoveAsync(product);
          

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
 
        }

    }
}
