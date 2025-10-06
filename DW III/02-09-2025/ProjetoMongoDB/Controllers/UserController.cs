using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoMongoDB.Models;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjetoMongoDB.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        // GET do CREATE
        public IActionResult Create(string role)
        {
            ViewBag.Role = role;
            return View();
        }

        // POST do CREATE
        [HttpPost]
        public async Task<IActionResult> Create(User user, string role)
        {
            // Se estiver tudo ok com o modelo da classe, cria o usuário
            if(ModelState.IsValid)
            {
                // Atribuindo valores do objeto 'user'
                ApplicationUser appUser = new ApplicationUser();
                string userName = user.NomeCompleto.Replace(" ", "");
                var normalizedString = userName.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new StringBuilder();

                foreach(char letra in normalizedString)
                {
                    if(CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(letra);
                    }
                };

                userName = sb.ToString().Normalize(NormalizationForm.FormC);

                // Retirar tudo o que não for letras e numeros

                userName = Regex.Replace(userName, @"[^a-zA-Z0-9\s]", "");

                appUser.UserName = userName;
                appUser.Email = user.Email;
                appUser.NomeCompleto = user.NomeCompleto;

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, role);
                    //  ViewBag 'carrega' coisas pra view
                    ViewBag.Message = "Usuário cadastrado com sucesso!";
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            // Fim do IF

            return View(user); // Retorna os valores preenchidos para não ter a necessidade de reescrever

        }

        [Authorize(Roles = "Administrador")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CreateRole(UserRole userRole)
        { 
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole() { Name = userRole.RoleName });

                if (result.Succeeded)
                {
                    ViewBag.Message = "Tipo de usuário cadastrado com sucesso!";
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}
