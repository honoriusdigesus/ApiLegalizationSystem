using ApiLegalizationSystem.Data.Models;
using ApiLegalizationSystem.Domain.Exceptions.Exception;
using ApiLegalizationSystem.Domain.Mappers;
using ApiLegalizationSystem.Domain.Models;
using ApiLegalizationSystem.Domain.Utils;

namespace ApiLegalizationSystem.Domain.UseCases
{
    public class CreateUserUseCase
    {
        private readonly LegalizationSystemContext _context;
        private readonly UserDomainMapper _mapper;
        private readonly Helpper _helpper;

        public CreateUserUseCase(LegalizationSystemContext context, UserDomainMapper mapper, Helpper helpper)
        {
            _context = context;
            _mapper = mapper;
            _helpper = helpper;
        }

        public async Task<UserResponseDomain> CreateUser(UserRequestDomain userDomain)
        {
            if (userDomain == null)
            {
                throw new UserException("El usuario no puede ser nulo");
            }

            var user = _mapper.fromDomainToData(userDomain);
            user.PasswordHash = _helpper.encryptTokenSHA256(user.PasswordHash);
            //Capturar el string del Enum Role
            user.Role = Roles.Field.ToString();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.fromDataToDomain(user);
        }
    }
}
