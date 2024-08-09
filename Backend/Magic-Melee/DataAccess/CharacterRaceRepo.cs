using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMelee.Data;

public class CharacterRaceRepo : ICharacterRaceRepo
{
    private readonly MagicMeleeContext _context;

    public CharacterRaceRepo(MagicMeleeContext context)
    {
        _context = context;
    }

    public async Task<CharacterRace> GetByIdAsync(int id)
    {
        return await _context.CharacterRaces.FindAsync(id);
    }

    public async Task<IEnumerable<CharacterRace>> GetAllAsync()
    {
        return await _context.CharacterRaces.ToListAsync();
    }

    public async Task AddAsync(CharacterRace entity)
    {
        await _context.CharacterRaces.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CharacterRace entity)
    {
        _context.CharacterRaces.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var race = await _context.CharacterRaces.FindAsync(id);
        if (race != null)
        {
            _context.CharacterRaces.Remove(race);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<CharacterRace> GetByCharacterIdAsync(int characterId)
    {
        return await _context.CharacterRaces
            .Include(cr => cr.DndCharacter)
            .FirstOrDefaultAsync(cr => cr.DndCharacter.CharacterId == characterId);
    }
}