using E_Commerce.Errors;
using infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        public BuggyController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("NotFound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = _context.products.Find(50);
            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(thing); 
        }
        [HttpGet("getServerError")]
        public IActionResult GetServerError()
        {
            try
            {
                var thing = _context.products.Find(50);
                if (thing != null)
                {
                    var returnthing = thing.ToString();
                    return Ok(returnthing);
                }
                return StatusCode(500, "Internal Server Error: ");

            }
            catch (Exception ex)
            {   
                // Handle the exception here, you can log it or return an error response
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        [HttpGet("GetBadRequest")]

        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("GetNotFoundRequest")]

        public IActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
        
    }
}
