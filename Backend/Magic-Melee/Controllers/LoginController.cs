using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using MagicMelee.Models;
using MagicMelee.Services;


public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
[HttpPost("login")]
public async Task<IActionResult> Login(string Username, string Password)
{
    if (ModelState.IsValid)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user != null && await _userManager.CheckPasswordAsync(user, Password))
        {
           // Generate token
            var token = GenerateJwtToken(user);

            //Return token!
            return Ok(new { Token = token });
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
    }

    return View();
}
}