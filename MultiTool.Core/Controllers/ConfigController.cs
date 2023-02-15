using Microsoft.AspNetCore.Mvc;

namespace MultiTool.Core.Controllers
{
    [Route("[controller]/[action]")]
    public class ConfigController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
