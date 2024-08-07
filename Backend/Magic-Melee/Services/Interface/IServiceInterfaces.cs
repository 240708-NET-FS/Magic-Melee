using MagicMelee.DTO;

namespace MagicMelee.Services;

public interface ILoginService
{
    Task<string> LoginAsync(LoginDTO userLogin);
    // Task<LoginDTO> GetByIdAsync(int id);
    // Task<IEnumerable<LoginDTO>> GetAllAsync();
    // Task AddAsync(LoginDTO login);
    // Task UpdateAsync(LoginDTO login);
    // Task DeleteAsync(int id);
    // Task<UserDTO> GetUserByUsernameAsync(string username);
    // Task<bool> VerifyPasswordAsync(UserDTO user, string password);
}

public interface IUserService
{
    Task<UserDTO> GetByIdAsync(int id);
    Task<IEnumerable<UserDTO>> GetAllAsync();
    Task AddAsync(UserDTO user);
    Task UpdateAsync(UserDTO user);
    Task DeleteAsync(int id);
}

public interface ICharacterClassService
{
    Task<CharacterClassDTO> GetByIdAsync(int id);
    Task<IEnumerable<CharacterClassDTO>> GetAllAsync();
    Task AddAsync(CharacterClassDTO characterClass);
    Task UpdateAsync(CharacterClassDTO characterClass);
    Task DeleteAsync(int id);
}

public interface IDndCharacterService
{
    Task<DndCharacterDTO> GetByIdAsync(int id);
    Task<IEnumerable<DndCharacterDTO>> GetAllAsync();
    Task AddAsync(DndCharacterDTO character);
    Task UpdateAsync(DndCharacterDTO character);
    Task DeleteAsync(int id);
}

public interface ISpellService
{
    Task<SpellDTO> GetByIdAsync(int id);
    Task<IEnumerable<SpellDTO>> GetAllAsync();
    Task AddAsync(SpellDTO spell);
    Task UpdateAsync(SpellDTO spell);
    Task DeleteAsync(int id);
}

public interface ISkillsService
{
    Task<SkillsDTO> GetByIdAsync(int id);
    Task<IEnumerable<SkillsDTO>> GetAllAsync();
    Task AddAsync(SkillsDTO skills);
    Task UpdateAsync(SkillsDTO skills);
    Task DeleteAsync(int id);
}