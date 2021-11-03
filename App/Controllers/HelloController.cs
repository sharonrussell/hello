using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name should be supplied");
            }

            return Ok($"Hello, {name}");
        }
    }
}
