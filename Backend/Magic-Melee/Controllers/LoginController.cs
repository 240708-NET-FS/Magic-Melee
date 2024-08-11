using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicMelee.Models;
using MagicMelee.Services;

namespace MagicMelee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _loginService.LoginAsync(loginModel.Username, loginModel.Password);

            if (result.GetType() == typeof(System.Dynamic.ExpandoObject))
            {
                var expando = (dynamic)result;
                if (expando.Token != null)
                {
                    return Ok(new { Token = expando.Token });
                }
                else
                {
                    return BadRequest(new { Error = expando.Error });
                }
            }

            return StatusCode(500, "Unexpected error");
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}