namespace MagicMelee.Data;

public class LoginRepo : ILoginRepo
{
    private readonly MagicMeleeContext _context;

    public LoginRepo(MagicMeleeContext context)
    {
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