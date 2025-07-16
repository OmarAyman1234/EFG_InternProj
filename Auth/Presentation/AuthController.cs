using Microsoft.AspNetCore.Mvc;
using Auth.Application.UseCases;
using OrderSharedContent;

namespace Auth.Presentation
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly RefreshRouteUseCase _refreshRouteUseCase;
        public AuthController(LoginUserUseCase loginUserUseCase, RegisterUserUseCase registerUserUseCase, RefreshRouteUseCase refreshRouteUseCase)
        {
            _loginUserUseCase = loginUserUseCase;
            _registerUserUseCase = registerUserUseCase;
            _refreshRouteUseCase = refreshRouteUseCase;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginRequest lr)
        {
            try
            {
                string accessToken = _loginUserUseCase.Execute(lr);
                return Ok(new { accessToken });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not found"))
                    return NotFound(ex.Message);

                if(ex.Message.Contains("Incorrect"))
                    return Unauthorized(ex.Message);

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterRequest rr)
        {
            try
            {
                _registerUserUseCase.Execute(rr);
                return Created("",$"New user: {rr.Username}");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("don't match"))
                    return BadRequest(ex.Message);
                if (ex.Message.Contains("already taken"))
                    return Conflict(ex.Message);

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("refresh")]
        public ActionResult<string> Refresh()
        {
            try
            {
                string newAccessToken = _refreshRouteUseCase.Execute();
                return Ok(newAccessToken);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("login"))
                    return Unauthorized(ex.Message);

                return StatusCode(500, ex.Message);
            }
        }
    }
}
