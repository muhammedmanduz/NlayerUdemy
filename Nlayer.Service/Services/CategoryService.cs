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
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, ICategoryRepository categoryRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductasDto>> GetSingleCategoryByIdWithProductAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductAsync(categoryId);

            var categoryDto=_mapper.Map<CategoryWithProductasDto>(category);
            return  CustomResponseDto<CategoryWithProductasDto>.Success(200,categoryDto);
        }
    }
}
