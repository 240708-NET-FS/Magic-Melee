using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMelee.Data;

public class CharacterClassRepo : ICharacterClassRepo
{
    private readonly MagicMeleeContext _context;

    public CharacterClassRepo(MagicMeleeContext context)
    {
        _context = context;
    }

    public async Task<CharacterClass> GetByIdAsync(int id)
    {
        return await _context.CharacterClasses.FindAsync(id);
    }

    public async Task<IEnumerable<CharacterClass>> GetAllAsync()
    {
        return await _context.CharacterClasses.ToListAsync();
    }

    public async Task<int> AddAsync(CharacterClass entity)
    {
        await _context.CharacterClasses.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.CharacterClassId;
    }

    public async Task UpdateAsync(CharacterClass entity)
    {
        _context.CharacterClasses.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var characterClass = await _context.CharacterClasses.FindAsync(id);
        if (characterClass != null)
        {
            _context.CharacterClasses.Remove(characterClass);
            await _context.SaveChangesAsync();
        }
    }
}