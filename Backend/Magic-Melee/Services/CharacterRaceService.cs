using MagicMelee.Data;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;

namespace MagicMelee.Services;

public class CharacterRaceService : ICharacterRaceService
{
    private readonly ICharacterRaceRepo _characterRaceRepo;
    private readonly ILogger<CharacterRaceService> _logger;

    public CharacterRaceService(ICharacterRaceRepo characterRaceRepo, ILogger<CharacterRaceService> logger)
    {
        _characterRaceRepo = characterRaceRepo;
        _logger = logger;
    }

    public async Task<CharacterRaceDTO> GetByIdAsync(int id)
    {
        try
        {
            var characterRace = await _characterRaceRepo.GetByIdAsync(id);
            if (characterRace == null)
            {
                _logger.LogWarning("Character race not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Character race not found with ID: {id}");
            }
            return CharacterRaceUtility.CharacterRaceToDTO(characterRace);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve character race by ID: {Id}", id);
            throw new MagicMeleeException("Error retrieving character race", ex);
        }
    }

    public async Task<IEnumerable<CharacterRaceDTO>> GetAllAsync()
    {
        try
        {
            var characterRaces = await _characterRaceRepo.GetAllAsync();
            return characterRaces.Select(CharacterRaceUtility.CharacterRaceToDTO).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve all character races");
            throw new MagicMeleeException("Error retrieving all character races", ex);
        }
    }

    public async Task<int> AddAsync(CharacterRaceDTO characterRaceDto)
    {
        try
        {
            var characterRace = CharacterRaceUtility.DTOToCharacterRace(characterRaceDto);
            return await _characterRaceRepo.AddAsync(characterRace);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add character race: {CharacterRaceDto}", characterRaceDto);
            throw new MagicMeleeException("Error adding character race", ex);
        }
    }

    public async Task UpdateAsync(CharacterRaceDTO characterRaceDto)
    {
        try
        {
            var characterRace = await _characterRaceRepo.GetByIdAsync(characterRaceDto.CharacterRaceId);
            if (characterRace == null)
            {
                _logger.LogWarning("Character race not found with ID: {Id}", characterRaceDto.CharacterRaceId);
                throw new CharacterNotFoundException($"Character race not found with ID: {characterRaceDto.CharacterRaceId}");
            }

            characterRace = CharacterRaceUtility.DTOToCharacterRace(characterRaceDto); // Updating fields from DTO
            await _characterRaceRepo.UpdateAsync(characterRace);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update character race: {CharacterRaceDto}", characterRaceDto);
            throw new MagicMeleeException("Error updating character race", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var characterRace = await _characterRaceRepo.GetByIdAsync(id);
            if (characterRace == null)
            {
                _logger.LogWarning("Character race not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Character race not found with ID: {id}");
            }

            await _characterRaceRepo.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete character race by ID: {Id}", id);
            throw new MagicMeleeException("Error deleting character race", ex);
        }
    }

    public async Task<CharacterRaceDTO> GetByCharacterIdAsync(int characterId)
    {
        try
        {
            var characterRace = await _characterRaceRepo.GetByCharacterIdAsync(characterId);
            if (characterRace == null)
            {
                _logger.LogWarning("Character race not found for character ID: {CharacterId}", characterId);
                throw new CharacterNotFoundException($"Character race not found for character ID: {characterId}");
            }
            return CharacterRaceUtility.CharacterRaceToDTO(characterRace);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve character race for character ID: {CharacterId}", characterId);
            throw new MagicMeleeException("Error retrieving character race for character", ex);
        }
    }
}