using Lojinha.Infra.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/roles")]
    [Authorize(Roles = "Admin")]
    public class AdminRolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManage;
        private UserManager<IdentityUser> _userManage;
        public AdminRolesController(RoleManager<IdentityRole> roleManage, UserManager<IdentityUser> userManage)
        {
            this._roleManage = roleManage;
            this._userManage = userManage;
        }
        [HttpGet]
        public ActionResult Index()
        {
            IList<IdentityRole> roles = new List<IdentityRole>();
            dynamic result =  _roleManage.Roles;
            foreach (var item in result)
            {
                roles.Add(item);
            }
            
            return new ObjectResult(roles);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {

            if(ModelState.IsValid)
            {
                dynamic result = await _roleManage.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    foreach (var item in _roleManage.Roles)
                    {
                        if(item.Name == name)
                        {
                            return new ObjectResult(_roleManage.Roles);
                        }
                    }
                }
                else
                    return new ObjectResult(result);
            }
            return new ObjectResult(_roleManage.Roles);
        }

        [HttpGet("update")]
        ///<sumary> atualizar roles 
        ///</sumary>
        ///<param name="id"></param>
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await _roleManage.FindByIdAsync(id);
          

            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonMembers = new List<IdentityUser>();

            foreach (IdentityUser user in _userManage.Users)
            {
                var list = await _userManage.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return new ObjectResult(new RoleEditModel { 
                Role = role,
                NonMembers = nonMembers,
                Members = members,

            });
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(RoleUpdateModel model)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    IdentityUser user = await _userManage.FindByIdAsync($"{userId}");

                    if(user != null)
                    {
                        result = await _userManage.AddToRoleAsync(user, model.RoleName);
                  
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    IdentityUser user = await _userManage.FindByIdAsync($"{userId}");

                    if (user != null)
                    {
                        result = await _userManage.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            return new ObjectResult(result);
                    }
                }
            }

            if(ModelState.IsValid)
            {
                return new ObjectResult("edpoint:url");
            }
            else
            {
                return new ObjectResult(model);
            }
        }
    }
}
