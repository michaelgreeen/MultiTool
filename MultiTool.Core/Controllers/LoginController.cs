using Microsoft.AspNetCore.Mvc;

namespace MultiTool.Core.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
