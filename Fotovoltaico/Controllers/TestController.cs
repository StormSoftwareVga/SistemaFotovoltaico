using Microsoft.AspNetCore.Mvc;

namespace Fotovoltaico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "API está funcionando!" });
        }
    }
}
