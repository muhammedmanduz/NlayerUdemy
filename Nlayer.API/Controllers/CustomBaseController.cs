using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NlayerCore.DTOs;

namespace Nlayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction] //Endpoint olmadıgını gostermek için
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response) //bu kod endpoint değil
        {
            if (response.StatusCode == 204)
            
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode
                };

            
        }
    }
}
