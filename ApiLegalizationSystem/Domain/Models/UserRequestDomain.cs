using ApiLegalizationSystem.Domain.Utils;

namespace ApiLegalizationSystem.Domain.Models
{
    public class UserRequestDomain
    {
        public int IdentityDocument { get; set; }

        public string FullName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public String? Role { get; set; }
    }
}
