using ApiLegalizationSystem.Data.Models;
using ApiLegalizationSystem.Domain.Models;

namespace ApiLegalizationSystem.Domain.Mappers
{
    public class UserDomainMapper
    {
        //Convertimos el usuario tipo Domain a tipo Data
        public User fromDomainToData(UserRequestDomain userDomain)
        {
            return new User
            {
                IdentityDocument = userDomain.IdentityDocument,
                FullName = userDomain.FullName,
                LastName = userDomain.LastName,
                Email = userDomain.Email,
                PasswordHash = userDomain.PasswordHash,
                Role = userDomain.Role
            };
        }

        //Convertimos el usuario tipo Data a tipo UserResponseDomain
        public UserResponseDomain fromDataToUserResponseDomain(User user)
        {
            return new UserResponseDomain
            {
                Id = user.UserId,
                FullName = user.FullName,
                Role = user.Role
            };
        }

    }
}
