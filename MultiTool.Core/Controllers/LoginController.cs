using Microsoft.AspNetCore.Mvc;

namespace MultiTool.Core.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return Ok();
        }
    }
}
