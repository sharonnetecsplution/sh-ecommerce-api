using Lojinha.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Services
{
    public class SeedUserClaimsInitial : ISeedUserClaimsInitial
    {
        private readonly UserManager<IdentityUser> _userManager;

        public SeedUserClaimsInitial(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task SeedUserClaims()
        {
            try
            {
                IdentityUser user1 = await _userManager.FindByEmailAsync("edvanderson@hotmail.com");
                if (user1 == null)
                {
                    var claimList = (await _userManager.GetClaimsAsync(user1)).Select(p => p.Type);

                    if (!claimList.Contains("CadastradoEm"))
                    {
                        var claimResult1 = await _userManager.AddClaimAsync(user1, new Claim("CadastradoEm", "09/04/2023"));
                    }
                    if (!claimList.Contains("IsAdmin"))
                    {
                        var claimResult2 = await _userManager.AddClaimAsync(user1, new Claim("IsAdmin", "true"));
                    }
                }

                IdentityUser user2 = await _userManager.FindByEmailAsync("edvan@hotmail.com");
                if (user1 == null)
                {
                    var claimList = (await _userManager.GetClaimsAsync(user2)).Select(p => p.Type);

                    if (!claimList.Contains("IsAdmin"))
                    {
                        var claimResult = await _userManager.AddClaimAsync(user1, new Claim("IsAdmin", "true"));
                    }
                    if (!claimList.Contains("IsAdmin"))
                    {
                        var claimResult = await _userManager.AddClaimAsync(user1, new Claim("Isfuncionario", "true"));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
