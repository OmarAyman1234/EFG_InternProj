using Microsoft.AspNetCore.Mvc;
using Auth.Data.Repositories;
using OrderSharedContent;

namespace Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices) 
        { 
            _authServices = authServices;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginRequest lr)
        {
            try
            {
                string accessToken = _authServices.LoginUser(lr);
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
                _authServices.RegisterUser(rr);
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
                string newAccessToken = _authServices.Refresh();
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
