// Auth/JwtService.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BackendAPI.Models;

namespace BackendAPI.Auth;

public class JwtService
{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user)
    {
        // ✅ Claims (important for auth + role-based access)
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Role, user.Role ?? "User")
        };

        // ✅ Safe key handling (prevents null crash)
        var keyString = _config["Jwt:Key"] ?? throw new Exception("JWT Key not configured");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // ✅ Token creation
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"] ?? "default_issuer",
            audience: _config["Jwt:Audience"] ?? "default_audience",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}