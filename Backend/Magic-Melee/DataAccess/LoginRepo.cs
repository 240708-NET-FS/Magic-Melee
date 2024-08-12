using System.Linq.Expressions;
using MagicMelee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MagicMelee.DTO;
namespace MagicMelee.Data;

public class LoginRepo : ILoginRepo
{
    private readonly UserManager<User> _userManager;
    private readonly MagicMeleeContext _context;

    public LoginRepo(UserManager<User> userManager, MagicMeleeContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<Login> GetByIdAsync(int id)
    {
        return await _context.Logins.FindAsync(id);
    }

    public async Task<IEnumerable<Login>> GetAllAsync()
    {
        return await _context.Logins.ToListAsync();
    }

    public async Task<int> AddAsync(Login entity)
    {
        await _context.Logins.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.LoginId;
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

    public async Task<bool> VerifyPasswordAsync(User user, string password)
    {
         return await _userManager.CheckPasswordAsync(user, password);
    }


    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var login = await _context.Logins
            .Include(l => l.User)  // Ensure the User entity is loaded
            .FirstOrDefaultAsync(l => l.Username == username);

            return login?.User;
    }
}