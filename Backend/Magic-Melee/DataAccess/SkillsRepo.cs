using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMelee.Data;

public class SkillsRepo : ISkillsRepo
{
    private readonly MagicMeleeContext _context;

    public SkillsRepo(MagicMeleeContext context)
    {
        _context = context;
    }

    public async Task<Skills> GetByIdAsync(int id)
    {
        return await _context.Skills.FindAsync(id);
    }

    public async Task<IEnumerable<Skills>> GetAllAsync()
    {
        return await _context.Skills.ToListAsync();
    }

    public async Task AddAsync(Skills entity)
    {
        await _context.Skills.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Skills entity)
    {
        _context.Skills.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var skills = await _context.Skills.FindAsync(id);
        if (skills != null)
        {
            _context.Skills.Remove(skills);
            await _context.SaveChangesAsync();
        }
    }
}