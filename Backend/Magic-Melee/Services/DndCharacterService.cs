using MagicMelee.Data;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;

namespace MagicMelee.Services;

public class DndCharacterService : IDndCharacterService
{
    private readonly IDndCharacterRepo _characterRepo;
    private readonly ILogger<DndCharacterService> _logger;

    public DndCharacterService(IDndCharacterRepo characterRepo, ILogger<DndCharacterService> logger)
    {
        _characterRepo = characterRepo;
        _logger = logger;
    }

    public async Task<DndCharacterDTO> GetByIdAsync(int id)
    {
        try
        {
            var character = await _characterRepo.GetByIdAsync(id);
            if (character == null)
            {
                _logger.LogWarning("DndCharacter not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"DndCharacter not found with ID: {id}");
            }
            return DndCharacterUtility.DndCharacterToDTO(character);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve DndCharacter by ID: {Id}", id);
            throw new MagicMeleeException("Error retrieving DndCharacter", ex);
        }
    }

    public async Task<IEnumerable<DndCharacterDTO>> GetByUserIdAsync(int userId)
    {
        try
        {
            var characters = await _characterRepo.GetByUserId(userId);
            if (!characters.Any())
            {
                _logger.LogWarning("No DndCharacters found for User ID: {UserId}", userId);
                return new List<DndCharacterDTO>();  // Return an empty list if no characters found
            }
            return characters.Select(c => DndCharacterUtility.DndCharacterToDTO(c)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve DndCharacters for User ID: {UserId}", userId);
            throw new MagicMeleeException($"Error retrieving DndCharacters for User ID: {userId}", ex);
        }
    }

    public async Task<IEnumerable<DndCharacterDTO>> GetAllAsync()
    {
        try
        {
            var characters = await _characterRepo.GetAllAsync();
            return characters.Select(DndCharacterUtility.DndCharacterToDTO).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve all DndCharacters");
            throw new MagicMeleeException("Error retrieving all DndCharacters", ex);
        }
    }

    public async Task AddAsync(DndCharacterDTO characterDTO)
    {
        try
        {
            // Here is where additional validation for character creation would go
            var character = DndCharacterUtility.DTOToDndCharacter(characterDTO);
            await _characterRepo.AddAsync(character);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add DndCharacter: {Character}", characterDTO);
            throw new MagicMeleeException("Error adding DndCharacter", ex);
        }
    }

    public async Task UpdateAsync(DndCharacterDTO characterDTO)
    {
        try
        {
            var character = await _characterRepo.GetByIdAsync(characterDTO.CharacterId);
            if (character == null)
            {
                _logger.LogWarning("DndCharacter not found with ID: {Id}", characterDTO.CharacterId);
                throw new CharacterNotFoundException($"DndCharacter not found with ID: {characterDTO.CharacterId}");
            }

            // Updating fields from DTO
            character = DndCharacterUtility.DTOToDndCharacter(characterDTO);

            await _characterRepo.UpdateAsync(character);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update DndCharacter: {Character}", characterDTO);
            throw new MagicMeleeException("Error updating DndCharacter", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var character = await _characterRepo.GetByIdAsync(id);
            if (character == null)
            {
                _logger.LogWarning("DndCharacter not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"DndCharacter not found with ID: {id}");
            }

            await _characterRepo.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete DndCharacter by ID: {Id}", id);
            throw new MagicMeleeException("Error deleting DndCharacter", ex);
        }
    }
}