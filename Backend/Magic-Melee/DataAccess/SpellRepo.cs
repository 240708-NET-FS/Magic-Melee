using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMelee.Data;

public class SpellRepo : ISpellRepo
{
    private readonly MagicMeleeContext _context;

    public SpellRepo(MagicMeleeContext context)
    {
        _context = context;
    }

    public async Task<Spell> GetByIdAsync(int id)
    {
        return await _context.Spells.FindAsync(id);
    }
    public async Task<Spell> GetByNameAsync(string name)
    {
        return await _context.Spells.FirstOrDefaultAsync(s => s.SpellName == name);
    }

    public async Task<IEnumerable<Spell>> GetAllAsync()
    {
        return await _context.Spells.ToListAsync();
    }

    public async Task AddAsync(Spell entity)
    {
        await _context.Spells.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Spell entity)
    {
        _context.Spells.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var spell = await _context.Spells.FindAsync(id);
        if (spell != null)
        {
            _context.Spells.Remove(spell);
            await _context.SaveChangesAsync();
        }
    }
}