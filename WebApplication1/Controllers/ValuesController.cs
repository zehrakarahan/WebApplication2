using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [EnableCors("AllowSpecificOrigin")]
        [HttpGet("Deneme")]
        public IActionResult GetDeneme()
        {
            return Ok("ali geldi");
        }
    }
}
