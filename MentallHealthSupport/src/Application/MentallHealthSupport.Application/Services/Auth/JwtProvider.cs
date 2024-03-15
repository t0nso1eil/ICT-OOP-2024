#pragma warning disable IDE0008

using MentallHealthSupport.Application.Models.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MentallHealthSupport.Application.Services.Auth;
public class JwtProvider(IOptions<JwtOption> options)
{
    private readonly JwtOption _options = options.Value;

    public string GenerateToken(Guid id)
    {
        Claim[] claims = { new Claim("user_id", id.ToString()) };
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
}