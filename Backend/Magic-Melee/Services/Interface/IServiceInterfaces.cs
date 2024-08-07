using MagicMelee.DTO;

namespace MagicMelee.Services;

public interface IRepositoryService<TDto>
{
    Task<TDto> GetByIdAsync(int id);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task AddAsync(TDto dto);
    Task UpdateAsync(TDto dto);
    Task DeleteAsync(int id);
}

public interface ILoginService // Inherit from IRepositoryService when ready
{
    Task<string> LoginAsync(LoginDTO userLogin);
}

public interface IUserService : IRepositoryService<UserDTO>
{
    // Specific methods for user service
}

public interface ICharacterClassService : IRepositoryService<CharacterClassDTO>
{
    // Specific methods for character class service
}

public interface IDndCharacterService : IRepositoryService<DndCharacterDTO>
{
    Task<IEnumerable<DndCharacterDTO>> GetByUserIdAsync(int userId);
}

public interface ISpellService : IRepositoryService<SpellDTO>
{
    // Specific methods for spell service
}

public interface ISkillsService : IRepositoryService<SkillsDTO>
{
    // Specific methods for skills service
}