// DTOs/AuthResponseDto.cs
namespace BackendAPI.DTOs;

public class AuthResponseDto
{
    public string Token { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}