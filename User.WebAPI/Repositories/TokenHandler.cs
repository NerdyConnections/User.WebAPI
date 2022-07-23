using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Domain.Models;

namespace User.WebAPI.Repositories
{
    public class TokenHandler:ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> CreateTokenAsync(Client _client)
        {
          
            //Create claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, _client.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, _client.LastName));
            claims.Add(new Claim(ClaimTypes.Email, _client.EmailAddress));

            _client.Roles.ForEach((role)=>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

            });
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));



        }
    }
}
