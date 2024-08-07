using MagicMelee.Models;

namespace MagicMelee.Data;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

public interface ILoginRepo : IRepository<Login>
{
    //define methods specific to login if needed
}

public interface IUserRepo : IRepository<User>
{
    // define methods specific to user if needed
}

public interface IDndCharacterRepo : IRepository<DndCharacter>
{
    // same
}

public interface ISpellRepo : IRepository<Spell>
{
    // same
}

public interface ICharacterRaceRepo : IRepository<CharacterRace>
{
    // same   
}

public interface ICharacterClassRepo : IRepository<CharacterClass>
{
    // same   
}

public interface IAbilityScoreArrRepo : IRepository<AbilityScoreArr>
{
    // same   
}

public interface ISkillsRepo : IRepository<Skills>
{
    // same   
}

// Add additional interfaces if needed