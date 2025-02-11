using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Copify.Interfaces;
using Copify.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace Copify.Service
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration)
        {   
            _configuration=configuration;
            _key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
        }
        public string CreateToken(AppUser appUser){
            var claims =new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Email,appUser.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,appUser.UserName),
            };
            var creds=new SigningCredentials(_key,SecurityAlgorithms.HmacSha256);
            var  tokenDescriptor=new SecurityTokenDescriptor(){
                Subject=new ClaimsIdentity(claims),
                Expires=DateAndTime.Now.AddDays(7),
                SigningCredentials=creds,
                Audience=_configuration["JWT:Audience"],
                Issuer=_configuration["JWT:Issuer"]
            };
            var tokenHandlel=new JwtSecurityTokenHandler();
            var token =tokenHandlel.CreateToken(tokenDescriptor);
            return tokenHandlel.WriteToken(token);
        }
    }
}