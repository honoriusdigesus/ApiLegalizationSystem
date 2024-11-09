using ApiLegalizationSystem.Domain.UseCases;
using ApiLegalizationSystem.Presenter.Mappers;
using ApiLegalizationSystem.Presenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLegalizationSystem.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;
        private readonly LoginRequestPresenterMapper _loginRequestPresenterMapper;

        public LoginController(LoginUseCase loginUseCase, LoginRequestPresenterMapper loginRequestPresenterMapper)
        {
            _loginUseCase = loginUseCase;
            _loginRequestPresenterMapper = loginRequestPresenterMapper;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> Login([FromBody] LoginRequestPresenter loginRequestPresenter)
        {
            var loginRequestDomain = _loginRequestPresenterMapper.fromPresenterToDomain(loginRequestPresenter);
            var login = await _loginUseCase.Login(loginRequestDomain);
            return Ok(login);
        }
    }


}
