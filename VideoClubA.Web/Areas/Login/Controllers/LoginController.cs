using Microsoft.AspNetCore.Mvc;

namespace VideoClubA.Web.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Area("Login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
