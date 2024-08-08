using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMelee.Data;

public class AbilityScoreArrRepo : IAbilityScoreArrRepo
{
    private readonly MagicMeleeContext _context;

    public AbilityScoreArrRepo(MagicMeleeContext context)
    {
        _context = context;
    }

    public async Task<AbilityScoreArr> GetByIdAsync(int id)
    {
        return await _context.AbilityScoreArrs.FindAsync(id);
    }

    public async Task<IEnumerable<AbilityScoreArr>> GetAllAsync()
    {
        return await _context.AbilityScoreArrs.ToListAsync();
    }

    public async Task AddAsync(AbilityScoreArr entity)
    {
        await _context.AbilityScoreArrs.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AbilityScoreArr entity)
    {
        _context.AbilityScoreArrs.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var abilityScoreArr = await _context.AbilityScoreArrs.FindAsync(id);
        if (abilityScoreArr != null)
        {
            _context.AbilityScoreArrs.Remove(abilityScoreArr);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<AbilityScoreArr> GetByCharacterIdAsync(int characterId)
    {
        return await _context.AbilityScoreArrs
            .Include(a => a.DndCharacter)
            .FirstOrDefaultAsync(a => a.DndCharacter.CharacterId == characterId);
    }
}