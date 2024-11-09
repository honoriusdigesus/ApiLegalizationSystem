using ApiLegalizationSystem.Data.Models;
using ApiLegalizationSystem.Domain.Exceptions.Exception;
using ApiLegalizationSystem.Domain.Mappers;
using ApiLegalizationSystem.Domain.Models;
using ApiLegalizationSystem.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ApiLegalizationSystem.Domain.UseCases
{
    public class LoginUseCase
    {
        private readonly LegalizationContext _context;
        private readonly UserDomainMapper _mapper;
        private readonly Helpper _helpper;
        private readonly UtilsJwt _utilsJwt;

        public LoginUseCase(LegalizationContext context, UserDomainMapper mapper, Helpper helpper, UtilsJwt utilsJwt)
        {
            _context = context;
            _mapper = mapper;
            _helpper = helpper;
            _utilsJwt = utilsJwt;
        }

        public async Task<IActionResult> Login(LoginRequestDomain loginRequestDomain)
        {
            if (loginRequestDomain == null || loginRequestDomain.Email.Equals("") || loginRequestDomain.PasswordHash.Equals(""))
            {
                throw new UserException("Verifique la información del usuario");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == loginRequestDomain.Email && u.PasswordHash == _helpper.encryptTokenSHA256(loginRequestDomain.PasswordHash));
            if (user == null)
            {
                throw new UserException("El usuario no existe");
            }
           var token = _utilsJwt.generateJwt(_mapper.fromDataToUserResponseDomain(user));
            return new OkObjectResult(new { user = _mapper.fromDataToUserResponseDomain(user), token });
        }

    }
}
