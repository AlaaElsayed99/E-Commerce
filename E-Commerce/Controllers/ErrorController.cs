using E_Commerce.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    public class ErrorController : BaseApiController
    {
        [HttpGet]   
        public IActionResult Error(int code )
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
