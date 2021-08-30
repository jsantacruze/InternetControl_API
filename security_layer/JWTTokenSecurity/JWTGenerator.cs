using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using business_layer.IdentitySecurity.Contracts;
using domain_layer.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

namespace security_layer.JWTTokenSecurity
{
    public class JWTGenerator : IJWTGenerator
    {
        public string GenerateToken(User user, List<string> roles)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };
            if(roles != null){
                foreach(var role in roles){
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Esta es mi palabra clave para el token"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = credenciales
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}