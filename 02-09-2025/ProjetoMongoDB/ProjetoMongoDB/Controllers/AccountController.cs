using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoMongoDB.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMongoDB.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login
            (
                [Required][EmailAddress] string email,
                [Required] string password
            )
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appuser = await _userManager.FindByEmailAsync(email);

                if(appuser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appuser, password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError(nameof(email), "Verifique suas credenciais");
                }
            }

            return View();
        }

        [Authorize]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
