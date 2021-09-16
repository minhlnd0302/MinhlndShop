using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinhlndShop.Model.Model;
using MinhlndShop.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MinhlndShop.API.JWT
{
    public class JwtAction
    {
        public JwtAction()
        {
        }
        public static JwtAction GetInstance()
        {
            return new JwtAction();
        } 
        public string GenerateJwtToken(User user, JwtConfig jwtConfig)
        {  
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.UserName.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtConfig.Issuer,
                audience: jwtConfig.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodetoken;
        }
    }
}
