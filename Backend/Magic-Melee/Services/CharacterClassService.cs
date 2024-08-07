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
        try
        {
            var characterClasses = await _characterClassRepo.GetAllAsync();
            return characterClasses.Select(CharacterClassUtility.CharacterClassToDTO).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve all character classes");
            throw new MagicMeleeException("Error retrieving all character classes", ex);
        }
    }

    public async Task AddAsync(CharacterClassDTO characterClassDto)
    {
        try
        {
            var characterClass = CharacterClassUtility.DTOToCharacterClass(characterClassDto);
            await _characterClassRepo.AddAsync(characterClass);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add character class: {CharacterClassDto}", characterClassDto);
            throw new MagicMeleeException("Error adding character class", ex);
        }
    }

    public async Task UpdateAsync(CharacterClassDTO characterClassDto)
    {
        try
        {
            var characterClass = await _characterClassRepo.GetByIdAsync(characterClassDto.CharacterClassId);
            if (characterClass == null)
            {
                _logger.LogWarning("Character class not found with ID: {Id}", characterClassDto.CharacterClassId);
                throw new CharacterNotFoundException($"Character class not found with ID: {characterClassDto.CharacterClassId}");
            }

            characterClass = CharacterClassUtility.DTOToCharacterClass(characterClassDto); // Updating fields from DTO
            await _characterClassRepo.UpdateAsync(characterClass);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update character class: {CharacterClassDto}", characterClassDto);
            throw new MagicMeleeException("Error updating character class", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var characterClass = await _characterClassRepo.GetByIdAsync(id);
            if (characterClass == null)
            {
                _logger.LogWarning("Character class not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Character class not found with ID: {id}");
            }

            await _characterClassRepo.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete character class by ID: {Id}", id);
            throw new MagicMeleeException("Error deleting character class", ex);
        }
    }
}