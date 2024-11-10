using ApiLegalizationSystem.Data.Models;
using ApiLegalizationSystem.Domain.Exceptions.Exception;
using ApiLegalizationSystem.Domain.Mappers;
using ApiLegalizationSystem.Domain.Models;
using ApiLegalizationSystem.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<LoginResponse> Login(LoginRequestDomain loginRequestDomain)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginRequestDomain.Email && x.PasswordHash == _helpper.EncryptPassword(loginRequestDomain.PasswordHash));
            if (user == null)
            {
                throw new MyUserException("User not found");
            }

            var token = _utilsJwt.generateJwt(_mapper.fromDataToUserResponseDomain(user));
            var userResponse =_mapper.fromDataToUserResponseDomain(user);
            var loginResponseDom = new LoginResponse
            {
                Token = token,
                UserResponse = userResponse
            };
            return loginResponseDom;
        }

    }
}
