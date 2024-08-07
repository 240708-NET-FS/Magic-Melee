using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MagicMelee.Data;

public class LoginRepo : ILoginRepo
{
    private readonly MagicMeleeContext _context;

    private readonly UserManager<User> _userManager;

    public LoginRepo(MagicMeleeContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Login> GetByIdAsync(int id)
    {
        return await _context.Logins.FindAsync(id);
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task<bool> VerifyPasswordAsync(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IEnumerable<Login>> GetAllAsync()
    {
        return await _context.Logins.ToListAsync();
    }

    public async Task AddAsync(Login entity)
    {
        await _context.Logins.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Login entity)
    {
        _context.Logins.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var login = await _context.Logins.FindAsync(id);
        if (login != null)
        {
            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();
        }
    }
}