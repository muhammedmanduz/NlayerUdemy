using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NlayerCore.DTOs;

namespace Nlayer.API.Filters
{
    public class ValidateFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors=context.ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage).ToList();//hata sınıfı 
                
                context.Result=new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400,errors));

            }
        }

    }
}
