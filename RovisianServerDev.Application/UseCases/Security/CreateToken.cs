using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RovisianServerDev.Application.UseCases.Security
{
    public interface ICreateTokenUseCase : IUseCase<string, UserDTO> {}

    public class CreateToken : ICreateTokenUseCase
    {
        private readonly IConfiguration _configuration;
        public CreateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> Call(UserDTO? user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user!.Nombre),
                new Claim("User", user.Cedula),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddDays(3)
            );

            var token = new JwtSecurityToken(header, payload);

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
