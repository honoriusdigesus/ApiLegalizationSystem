namespace ApiLegalizationSystem.Domain.Models
{
    public class UserResponseDomain
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public String Role { get; set; } = null!;
    }
}
