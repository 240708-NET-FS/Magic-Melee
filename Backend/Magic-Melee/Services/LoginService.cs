using Magic_Melee.Services;
using MagicMelee.DTO;
using MagicMelee.Models;
using Microsoft.AspNetCore.Identity;

namespace MagicMelee.Services
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginDTO userLogin);
    }

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
            var user = await _loginRepo.GetUserByUsernameAsync(userLogin.Username);
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

    public interface ILoginRepo
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> VerifyPasswordAsync(User user, string password);
    }

    public class LoginRepo : ILoginRepo
    {
        private readonly UserManager<User> _userManager;

        public LoginRepo(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> VerifyPasswordAsync(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}


    