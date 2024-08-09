using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using MagicMelee.Models;


public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
[HttpPost]
public async Task<IActionResult> Login(string username, string password)
{
    if (ModelState.IsValid)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user != null && await _userManager.CheckPasswordAsync(user, password))
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
    }

    return View();
}
}