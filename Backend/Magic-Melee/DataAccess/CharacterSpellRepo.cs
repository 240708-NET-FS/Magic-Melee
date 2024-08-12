using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicMelee.Data;

public class CharacterSpellRepo : ICharacterSpellRepo
{
    private readonly MagicMeleeContext _context;

    public CharacterSpellRepo(MagicMeleeContext context)
    {
        _context = context;
    }

    public async Task<CharacterSpell> GetByIdAsync(int characterId, int spellId)
    {
        return await _context.CharacterSpells
            .FirstOrDefaultAsync(cs => cs.CharacterId == characterId && cs.SpellId == spellId);
    }
    public async Task<CharacterSpell> GetByNameAsync(string name) 
    {
        return await _context.CharacterSpells
            .FirstOrDefaultAsync( cs => cs.Spell.SpellName == name);
    }

    public async Task<IEnumerable<CharacterSpell>> GetAllAsync()
    {
        return await _context.CharacterSpells
                .Include(cs => cs.Spell)
                .ToListAsync();
    }

    public async Task AddAsync(CharacterSpell entity)
    {
        await _context.CharacterSpells.AddAsync(entity);
        await _context.SaveChangesAsync();
        //return entity.CharacterId;
    }

    public async Task UpdateAsync(CharacterSpell entity)
    {
        _context.CharacterSpells.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int characterId, int spellId)
    {
        var characterSpell = await _context.CharacterSpells
            .FirstOrDefaultAsync(cs => cs.CharacterId == characterId && cs.SpellId == spellId);
        if (characterSpell != null)
        {
            _context.CharacterSpells.Remove(characterSpell);
            await _context.SaveChangesAsync();
        }
    }
}