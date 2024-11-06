using ApiLegalizationSystem.Domain.UseCases;
using ApiLegalizationSystem.Presenter.Mappers;
using ApiLegalizationSystem.Presenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLegalizationSystem.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;
        private readonly UserPresenterMapper _userPresenterMapper;

        public UserController(CreateUserUseCase createUserUseCase, UserPresenterMapper userPresenterMapper)
        {
            _createUserUseCase = createUserUseCase;
            _userPresenterMapper = userPresenterMapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestPresenter userPresenter)
        {
            var userDomain = _userPresenterMapper.fromPresenterToDomain(userPresenter);
            var user = await _createUserUseCase.CreateUser(userDomain);
            var userPresenterResponse = _userPresenterMapper.fromDomainToPresenter(user);
            return Ok(userPresenterResponse);
        }
    }
}
