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
        return await _context.AbilityScoreArr.FindAsync(id);
    }

    public async Task<IEnumerable<AbilityScoreArr>> GetAllAsync()
    {
        return await _context.AbilityScoreArr.ToListAsync();
    }

    public async Task AddAsync(AbilityScoreArr entity)
    {
        await _context.AbilityScoreArr.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AbilityScoreArr entity)
    {
        _context.AbilityScoreArr.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var abilityScoreArr = await _context.AbilityScoreArr.FindAsync(id);
        if (abilityScoreArr != null)
        {
            _context.AbilityScoreArr.Remove(abilityScoreArr);
            await _context.SaveChangesAsync();
        }
    }
}