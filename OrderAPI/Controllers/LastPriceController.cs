using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastPriceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LastPriceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<int> Get()
        {
            try
            {
                return Ok(_configuration.GetValue<int>("LastPrice"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
