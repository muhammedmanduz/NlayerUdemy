using NlayerCore.DTOs;
using NlayerCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerCore.Services
{
    public interface ICategoryService:IService<Category>
    {
        public  Task<CustomResponseDto<CategoryWithProductasDto>> GetSingleCategoryByIdWithProductAsync(int categoryId);

    }
}
