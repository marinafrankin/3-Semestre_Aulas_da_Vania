﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoMongoDB.Models;

namespace ProjetoMongoDB.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
        }
        
        // GET do CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST do CREATE
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            // Se estiver tudo ok com o modelo da classe, cria o usuário
            if(ModelState.IsValid)
            {
                // Atribuindo valores do objeto 'user'
                ApplicationUser appUser = new ApplicationUser();
                appUser.UserName = "Marina";
                appUser.Email = user.Email;
                appUser.NomeCompleto = user.NomeCompleto;

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
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
    }
}
