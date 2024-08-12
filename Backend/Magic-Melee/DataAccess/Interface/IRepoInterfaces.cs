using MagicMelee.Models;

namespace MagicMelee.Data;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

public interface ILoginRepo : IRepository<Login>
{
    Task<User> GetUserByUsernameAsync(string username);
    Task<bool> VerifyPasswordAsync(User user, string password);
}

public interface IUserRepo : IRepository<User>
{
    // define methods specific to user if needed
}

public interface IDndCharacterRepo : IRepository<DndCharacter>
{
    Task<IEnumerable<DndCharacter>> GetByUserId(int userId);
}

public interface ISpellRepo : IRepository<Spell>
{
    // same
    Task<Spell> GetByNameAsync(string name);
}

public interface ICharacterRaceRepo : IRepository<CharacterRace>
{
    Task<CharacterRace> GetByCharacterIdAsync(int characterId); 
}

public interface ICharacterClassRepo : IRepository<CharacterClass>
{
    // same   
}

public interface IAbilityScoreArrRepo : IRepository<AbilityScoreArr>
{
    Task<AbilityScoreArr> GetByCharacterIdAsync(int characterId);   
}

public interface ISkillsRepo : IRepository<Skills>
{
    Task<Skills> GetByCharacterIdAsync(int characterId);
  
}

public interface ICharacterSpellRepo
{
    Task<CharacterSpell> GetByIdAsync(int characterId, int spellId);
    Task<IEnumerable<CharacterSpell>> GetAllAsync();
    Task AddAsync(CharacterSpell entity);
    Task UpdateAsync(CharacterSpell entity);
    Task DeleteAsync(int characterId, int spellId);
}

// Add additional interfaces if needed