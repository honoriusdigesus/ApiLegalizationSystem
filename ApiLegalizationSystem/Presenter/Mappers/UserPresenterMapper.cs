using ApiLegalizationSystem.Domain.Models;
using ApiLegalizationSystem.Presenter.Models;

namespace ApiLegalizationSystem.Presenter.Mappers
{
    public class UserPresenterMapper
    {
        //Convertir de UserRequestPresenter a UserRequestDomain
        public UserRequestDomain fromPresenterToDomain(UserRequestPresenter userPresenter)
        {
            return new UserRequestDomain
            {
                IdentityDocument = userPresenter.IdentityDocument,
                FullName = userPresenter.FullName,
                LastName = userPresenter.LastName,
                Email = userPresenter.Email,
                PasswordHash = userPresenter.PasswordHash
            };
        }

        //Convertir de UserResponseDomain a UserResponsePresenter
        public UserResponsePresenter fromDomainToPresenter(UserResponseDomain userDomain)
        {
            return new UserResponsePresenter
            {
                Id = userDomain.Id,
                FullName = userDomain.FullName,
                Role = userDomain.Role
            };
        }
    }
}
