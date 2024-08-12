using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMelee.Data;

public class DndCharacterRepo : IDndCharacterRepo
{
    private readonly MagicMeleeContext _context;

    public DndCharacterRepo(MagicMeleeContext context)
    {
         _context = context;
    }

    public async Task<DndCharacter> GetByIdAsync(int id)
    {
        return await _context.DndCharacters.FindAsync(id);
    }

    public async Task<IEnumerable<DndCharacter>> GetByUserId(int userId)
    {
        return await _context.DndCharacters
                            .Where(c => c.UserId == userId)
                            .ToListAsync();
    }

    public async Task<IEnumerable<DndCharacter>> GetAllAsync()
    {
        return await _context.DndCharacters.ToListAsync();
    }

    public async Task<int> AddAsync(DndCharacter entity)
    {
        await _context.DndCharacters.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.CharacterId;
    }

    public async Task UpdateAsync(DndCharacter entity)
    {
        _context.DndCharacters.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var character = await _context.DndCharacters.FindAsync(id);
        if (character != null)
        {
            _context.DndCharacters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
}