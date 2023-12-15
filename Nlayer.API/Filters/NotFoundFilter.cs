using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NlayerCore.DTOs;
using NlayerCore.Model;
using NlayerCore.Services;

namespace Nlayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValaue=context.ActionArguments.Values.FirstOrDefault();
            if (idValaue != null)
            {
                await next.Invoke();
                return;

            }

            var id=(int)idValaue;
            var anyEntity = await _service.AnyAsync(x=>x.Id==id);

            if (anyEntity)
            {
                await next.Invoke();
                return;

            }


            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));
        }
    }
}
