using Microsoft.AspNetCore.Mvc;

namespace Pr.Controllers
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
