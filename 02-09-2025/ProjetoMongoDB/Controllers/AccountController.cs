using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ProjetoMongoDB.Models;
using ProjetoMongoDB.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;

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

        // Métodos GET

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ForgotPassword()
        {
            View();
        }

        public IActionResult ForgotPasswordConsfirmation()
        {
            return View();
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public IActionResult ResetPassword(string token, string userId)
        {
            if (token == null || userId == null)
            {
                ModelState.AddModelError("", "Token inválido");
                return View();
            }

            var model = new ResetPasswordViewModel
            {
                token = token,
                UserId = userId
            };
            return View(model);
        }



        // Metodos POST

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            // Se  e-mail for null, entra aqui
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Informe o seu E-mail");
                return View();
            }

            // Instancia de usuario, para procura-lo por e-mail
            ApplicationUser user = await _userManager.FindByNameAsync(email);

            // Se o usuario for null, entra aqui
            if (user != null)
            { 
               return RedirectToAction("ForgotPasswordConfirmation"); 
            }

            // Se o usuario for encontrado, continua o progresso, criando um token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = HttpUtility.UrlEncode(token);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = encodedToken }, Request.Scheme);

            // Mosntar os elementos do e-mail
            string assunto = "Redefinição de senha";
            string corpo = $"Clique no link para redefinir sua senha: <a href='{callbackUrl}'>Redefinir senha</a>";

            await _emailService.SendEmailAsync(email, assunto, corpo); ;

            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            { 
                return View();
            }

            // Procurar o usuario pelo Id na Model
            var user = await _userManager.FindByIdAsync(model.Id);

            // Verifica se o usuario é null
            if (user == null)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            // Decofica o token
            var decodedToken = HttpUtility.UrlDecode(model.Token);

            var result = await _userManager.ResetPasswordAsync(user, decodedToken, model.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            // se tiver erros, serao coletados no ForEach
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
    }
}
