using MagicMelee.Data;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;

namespace MagicMelee.Services;

public class CharacterClassService : ICharacterClassService
{
    private readonly ICharacterClassRepo _characterClassRepo;
    private readonly ILogger<CharacterClassService> _logger;

    public CharacterClassService(ICharacterClassRepo characterClassRepo, ILogger<CharacterClassService> logger)
    {
        _characterClassRepo = characterClassRepo;
        _logger = logger;
    }

    public async Task<CharacterClassDTO> GetByIdAsync(int id)
    {
        try
        {
            var characterClass = await _characterClassRepo.GetByIdAsync(id);
            if (characterClass == null)
            {
                _logger.LogWarning("Character class not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Character class not found with ID: {id}");
            }
            return CharacterClassUtility.CharacterClassToDTO(characterClass);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve character class by ID: {Id}", id);
            throw new MagicMeleeException("Error retrieving character class", ex);
        }
    }

    public async Task<IEnumerable<CharacterClassDTO>> GetAllAsync()
    {
        var classes = await _characterClassRepo.GetAllAsync();
        return classes.Select(CharacterClassUtility.CharacterClassToDTO).ToList();
    }

    public async Task AddAsync(CharacterClassDTO characterClassDto)
    {
        var characterClass = CharacterClassUtility.DTOToCharacterClass(characterClassDto);
        await _characterClassRepo.AddAsync(characterClass);
    }

    public async Task UpdateAsync(CharacterClassDTO characterClassDto)
    {
        var characterClass = await _characterClassRepo.GetByIdAsync(characterClassDto.CharacterClassId);
        if (characterClass == null)
        {
            _logger.LogWarning("Character class not found with ID: {Id}", characterClassDto.CharacterClassId);
            throw new CharacterNotFoundException($"Character class not found with ID: {characterClassDto.CharacterClassId}");
        }
        characterClass = CharacterClassUtility.DTOToCharacterClass(characterClassDto);  // Update the character class with new DTO data
        await _characterClassRepo.UpdateAsync(characterClass);
    }

    public async Task DeleteAsync(int id)
    {
        var characterClass = await _characterClassRepo.GetByIdAsync(id);
        if (characterClass == null)
        {
            _logger.LogWarning("Character class not found with ID: {Id}", id);
            throw new CharacterNotFoundException($"Character class not found with ID: {id}");
        }
        await _characterClassRepo.DeleteAsync(id);
    }
}