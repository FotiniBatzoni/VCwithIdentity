using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoClubA.Authentication.Data.Account;
using VideoClubA.Web.Areas.Login.Models;


namespace VideoClubA.Web.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

        }

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }


        [HttpGet]
        [Area("Login")]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [Area("Login")]
        public async Task<IActionResult> PostLogin(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View();

            loginViewModel.RememberMe = true;

            var result = await signInManager.PasswordSignInAsync(
                loginViewModel.UserName,
                loginViewModel.Password,
                loginViewModel.RememberMe,
                false);


            if (result.Succeeded)
            {
                return RedirectToAction("MovieGallery", "Movie", new { area = "Movies" });
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "You are locked out.");
                }
                else
                {
                    ModelState.AddModelError("Login", "Failed to login.");
                }

                return RedirectToAction("Login", "Login", new { area = "Login" });
            }
        }
    }
}
