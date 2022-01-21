using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Northwind.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class TokenManager
    {
        IConfiguration _configuration;

        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Token üretilecek method

        public string CreateAccessToken(UserLoginDto userLoginDto)
        {
            // claims oluşturmak

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userLoginDto.UserCode),
                new Claim(JwtRegisteredClaimNames.Jti, userLoginDto.UserID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims,"Token");

            // claims roller

            var claimsRoleList = new List<Claim>
            {
                new Claim("roleAdmin","Admin")
            };

            // security key'in simetreğini almak

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            // şifrelenmiş kimlik oluşturmak

            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            // token ayarları

            var token = new JwtSecurityToken
                (
                   issuer:_configuration["Tokens:Issuer"], // Token dağıtıcı url
                   audience:_configuration["Tokens:Issuer"], // Erişilebilecek api bilgileri
                   expires: DateTime.Now.AddMinutes(5), // Token ömrünü belirleme
                   notBefore: DateTime.Now, // Token üretildikten sonra ne kadar süre sonra devreye girme
                   signingCredentials: cred, //  Kimliği verdik
                   claims :claimsIdentity.Claims // Claims'leri verdik
                );

            // token oluşturma sınıfı ile bir örnek alıp token üretmek

            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        } 
    }
}
