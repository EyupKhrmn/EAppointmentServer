using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EAppointmentServer.Application.Services;
using EAppointmentServer.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EAppointmentServer.Infrastructure.Services;

internal sealed class JwtProvider : IJwtProvider
{
    public string CreateToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.FullName ?? string.Empty),
            new Claim(ClaimTypes.Email,user.Email ?? string.Empty),
            new Claim("UserName",user.UserName ?? string.Empty),
        };

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(string.Join("-",Guid.NewGuid()
        ,Guid.NewGuid())));
        
        SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha512);
        
        JwtSecurityToken securityToken = new(
            issuer: "Eyup kahraman",
            audience: "eAppointment",
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signingCredentials);


        JwtSecurityTokenHandler tokenHandler = new();

        string token = tokenHandler.WriteToken(securityToken);

        return token;
    }
}