namespace ApiLegalizationSystem.Presenter.Models
{
    public class UserRequestPresenter
    {
        public int IdentityDocument { get; set; }

        public string FullName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
    }
}
