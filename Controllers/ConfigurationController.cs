using Microsoft.AspNetCore.Mvc;

namespace MultiTool.Core.Controllers
{
    [Route("[controller]/[action]")]
    public class ConfigurationController : Controller
    {
        public IActionResult GetConfiguration()
        {
            return View();
        }
    }
}
