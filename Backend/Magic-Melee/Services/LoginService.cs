using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MagicMelee.Models;
using MagicMelee.Services;

namespace MagicMelee.Services
{
    public class LoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;

        public LoginService(UserManager<User> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<object> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var token = _tokenService.GenerateJwtToken(user);
                return new { Token = token };
            }

            return new { Error = "Invalid login attempt." };
        }
    }
}

    