using MagicMelee.DTO;
using MagicMelee.Data;
using MagicMelee.Models;

namespace MagicMelee.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _loginRepo;
        private readonly ITokenService _tokenService;

        public LoginService(ILoginRepo loginRepo, ITokenService tokenService)
        {
            _loginRepo = loginRepo ?? throw new ArgumentNullException(nameof(loginRepo));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        public async Task<string> LoginAsync(LoginDTO userLogin)
        {
            var user = await _loginRepo.GetUserByUserIdAsync(userLogin.Username);
            if (user == null)
            {
                throw new Exception("Invalid login attempt");
            }

            var isPasswordValid = await _loginRepo.VerifyPasswordAsync(user, userLogin.Password);
            if (!isPasswordValid)
            {
                throw new Exception("Invalid login attempt");
            }

            return _tokenService.CreateToken(user);
        }
    }
}


    