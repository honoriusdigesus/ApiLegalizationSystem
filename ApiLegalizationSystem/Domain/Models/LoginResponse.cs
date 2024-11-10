namespace ApiLegalizationSystem.Domain.Models;

public class LoginResponse
{
    public string Token { get; set; } = null!;
    public UserResponseDomain UserResponse { get; set; } = null!;
}