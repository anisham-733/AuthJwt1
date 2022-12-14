using AuthJwt1.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthJwt1.Repository
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;
        public TokenHandler(IConfiguration configuration )
        {
            this.configuration = configuration;


        }
        public Task<string> CreateTokenAsync(TodoItem todoItem)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            //create claims for token
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, todoItem.Name));
            //more claims can be added

            //we will pass these creds to jwt security token
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(15),signingCredentials:creds);
            return Task.FromResult( new JwtSecurityTokenHandler().WriteToken(token));
  

        }
    }
}
