using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoClubA.Authentication.Data.Account;
using VideoClubA.Core.Interfaces;
using VideoClubA.Web.Areas.Register.Models;

namespace VideoClubA.Web.Areas.Register.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICustomerSevice _customerDb;

        public RegisterController(UserManager<User> userManager, ICustomerSevice customerDb)
        {
            this.userManager = userManager;
            _customerDb = customerDb;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        [HttpGet]
        [Area("Register")]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [Area("Register")]
        public async Task<IActionResult> PostRegister(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View();

            //Create the user
            var user = new User
            {
                Email = RegisterViewModel.Email,
                UserName = $"{RegisterViewModel.FirstName}{RegisterViewModel.LastName}"

            };

            var claimFirstName = new Claim("FirstName", RegisterViewModel.FirstName);
            var claimLastName = new Claim("LastName", RegisterViewModel.LastName);

            user.FirstName = claimFirstName.Value;
            user.LastName = claimLastName.Value;

            var userDb = _customerDb.GetCustomer(user.FirstName, user.LastName);

            user.UserID = userDb.Id;

            var result = await this.userManager.CreateAsync(user, RegisterViewModel.Password);
            if (result.Succeeded)
            {
                await this.userManager.AddClaimAsync(user, claimFirstName);
                await this.userManager.AddClaimAsync(user, claimLastName);

                var confirmationToken =
                    await this.userManager.GenerateEmailConfirmationTokenAsync(user);

                //var confirmationLink = Url.PageLink(pageName: "/Account/ConfirmEmail",
                //    values: new { userId = user.Id, token = confirmationToken }
                //    );

                return RedirectToAction("Login", "Login", new { area = "Login" });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }

                return RedirectToAction("Register", "Register", new { area = "Register" }); ;
            }
        }
    }
}
