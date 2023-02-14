using Microsoft.AspNetCore.Mvc;

namespace Pr.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return Ok("dupa");
        }
    }
}
