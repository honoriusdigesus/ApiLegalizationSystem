using ApiLegalizationSystem.Domain.Models;
using ApiLegalizationSystem.Presenter.Models;

namespace ApiLegalizationSystem.Presenter.Mappers
{
    public class LoginRequestPresenterMapper
    {
        //From LoginRequestPresenter to LoginRequestDomain
        public LoginRequestDomain fromPresenterToDomain(LoginRequestPresenter loginRequestPresenter)
        {
            return new LoginRequestDomain
            {
                Email = loginRequestPresenter.Email,
                PasswordHash = loginRequestPresenter.Password
            };
        }

        //From LoginRequestDomain to LoginRequestPresenter
        public LoginRequestPresenter fromDomainToPresenter(LoginRequestDomain loginRequestDomain)
        {
            return new LoginRequestPresenter
            {
                Email = loginRequestDomain.Email,
                Password = loginRequestDomain.PasswordHash
            };
        }
    }
}
