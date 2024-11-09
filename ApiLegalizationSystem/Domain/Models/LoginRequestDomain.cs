namespace ApiLegalizationSystem.Domain.Models
{
    public class LoginRequestDomain
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
