using FamilyRestourant.Entities;
using FamilyRestourant.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace LawProject.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<User> _userManager;
        public readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
        {
            if (!ModelState.IsValid) return View();

            User user = new User
            {
                FullName = newUser.FullName,
                Email = newUser.Email,

            };

            IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");

        }


        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (!ModelState.IsValid) return View();
            User existed = await _userManager.FindByEmailAsync(user.Email);

            if (existed == null)
            {
                existed = await _userManager.FindByNameAsync(user.Email);

                if (existed == null)
                {
                    ModelState.AddModelError(string.Empty, "Username or Password is not correct");
                    return View();
                }
            }

            var result = await _signInManager.PasswordSignInAsync(existed, user.Password,user.Reminder, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Block olunub gozleyin");
                return View();
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is not correct");
                return View();
            }


            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
