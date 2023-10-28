
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using  Lojinha.Infra.Data.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Lojinha.Infra.IoC.Outputs;

namespace Lojinha.Infra.IoC
{
    //te que ser movido para services
    public class Token
    {
      
        public  async Task<TokenOutput> GenerateToken(IdentityUser user, UserManager<IdentityUser> _UserManager)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");
            var tokenClaims = await ObterClaims(user, _UserManager);

            var dataExpiracao = DateTime.Now.AddMinutes(60);
            var jwt = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "Audience",
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
                );
            var token = tokenHandler.WriteToken(jwt);
            return new TokenOutput { Status = true, Token =token, dataExpiracao = dataExpiracao };
        }
        private async Task<IList<Claim>> ObterClaims(IdentityUser user, UserManager<IdentityUser> _UserManager)
        {
            var claims = await _UserManager.GetClaimsAsync(user);
            var roles = await _UserManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;

            
        }
    }
}
