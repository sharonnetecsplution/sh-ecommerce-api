using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC;
using Lojinha.Infra.IoC.Outputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/accounts")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly SignInManager<IdentityUser> _SignInManager;
       
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManage)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
        }
     
        [HttpPost("cadastro")]
        public async Task<ActionResult> Create(RegistreUserModel model)
        {

            if (ModelState.IsValid)
            {
                //Copia os dados de registro
                IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
                //Armazena os dados do usuario na tabela AspNetUsers
                var result = await _UserManager.CreateAsync(user, model.Password);
                //Se o usuario foi criado com sucesso, faz o login
                if (result.Succeeded)
                {
                    //Usando o servi;o SingInManager e rediciona para o Edpoint
                    await _SignInManager.SignInAsync(user, isPersistent: false);                    

                   
                    return new ObjectResult (new { user});
                }


                //se houver erro então incluir no modelState
                //que será  exibido pela tag hekper summary na validacao
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return new ObjectResult(ModelState);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserModel model)
        {

            if (ModelState.IsValid)
            {
                //Copia os dados de registro
                var result = await _SignInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);
                IdentityUser _user = new IdentityUser();
                if (result.Succeeded)
                {
                   
                    foreach (IdentityUser user in _UserManager.Users)
                    {
                        if(user.Email == model.Email)
                        {                      
                            _user =user;
                                   
                        }
                    }

                    dynamic roles =await _UserManager.GetRolesAsync(_user);
                   var token = new Token();
                   TokenOutput info_token = await token.GenerateToken(_user, _UserManager);

                    return new ObjectResult(new { _user, info_token });
                }


                ModelState.AddModelError(string.Empty, "Login Invalido");
            }
            return new ObjectResult(ModelState);

        }


        
      
    }
}
