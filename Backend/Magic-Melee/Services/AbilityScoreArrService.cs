using MagicMelee.Data;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;

namespace MagicMelee.Services;

public class AbilityScoreArrService : IAbilityScoreArrService
{
    private readonly IAbilityScoreArrRepo _abilityScoreArrRepo;
    private readonly ILogger<AbilityScoreArrService> _logger;

    public AbilityScoreArrService(IAbilityScoreArrRepo abilityScoreArrRepo, ILogger<AbilityScoreArrService> logger)
    {
        _abilityScoreArrRepo = abilityScoreArrRepo;
        _logger = logger;
    }

    public async Task<AbilityScoreArrDTO> GetByIdAsync(int id)
    {
        try
        {
            var abilityScoreArr = await _abilityScoreArrRepo.GetByIdAsync(id);
            if (abilityScoreArr == null)
            {
                _logger.LogWarning("Ability score array not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Ability score array not found with ID: {id}");
            }
            return AbilityScoreArrUtility.AbilityScoreArrToDTO(abilityScoreArr);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve ability score array by ID: {Id}", id);
            throw new MagicMeleeException("Error retrieving ability score array", ex);
        }
    }

    public async Task<IEnumerable<AbilityScoreArrDTO>> GetAllAsync()
    {
        try
        {
            var abilityScoreArrs = await _abilityScoreArrRepo.GetAllAsync();
            return abilityScoreArrs.Select(AbilityScoreArrUtility.AbilityScoreArrToDTO).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve all ability score arrays");
            throw new MagicMeleeException("Error retrieving all ability score arrays", ex);
        }
    }

    public async Task AddAsync(AbilityScoreArrDTO abilityScoreArrDto)
    {
        try
        {
            var abilityScoreArr = AbilityScoreArrUtility.DTOToAbilityScoreArr(abilityScoreArrDto);
            await _abilityScoreArrRepo.AddAsync(abilityScoreArr);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add ability score array: {AbilityScoreArrDto}", abilityScoreArrDto);
            throw new MagicMeleeException("Error adding ability score array", ex);
        }
    }

    public async Task UpdateAsync(AbilityScoreArrDTO abilityScoreArrDto)
    {
        try
        {
            var abilityScoreArr = await _abilityScoreArrRepo.GetByIdAsync(abilityScoreArrDto.AbilityScoreArrId);
            if (abilityScoreArr == null)
            {
                _logger.LogWarning("Ability score array not found with ID: {Id}", abilityScoreArrDto.AbilityScoreArrId);
                throw new CharacterNotFoundException($"Ability score array not found with ID: {abilityScoreArrDto.AbilityScoreArrId}");
            }

            //abilityScoreArr = AbilityScoreArrUtility.DTOToAbilityScoreArr(abilityScoreArrDto); // Updating fields from DTO
            abilityScoreArr.Str = abilityScoreArrDto.Str;
            abilityScoreArr.Dex = abilityScoreArrDto.Dex;
            abilityScoreArr.Con = abilityScoreArrDto.Con;
            abilityScoreArr.Int = abilityScoreArrDto.Int;
            abilityScoreArr.Wis = abilityScoreArrDto.Wis;
            abilityScoreArr.Cha = abilityScoreArrDto.Cha;
            await _abilityScoreArrRepo.UpdateAsync(abilityScoreArr);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update ability score array: {AbilityScoreArrDto}", abilityScoreArrDto);
            throw new MagicMeleeException("Error updating ability score array", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var abilityScoreArr = await _abilityScoreArrRepo.GetByIdAsync(id);
            if (abilityScoreArr == null)
            {
                _logger.LogWarning("Ability score array not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Ability score array not found with ID: {id}");
            }

            await _abilityScoreArrRepo.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete ability score array by ID: {Id}", id);
            throw new MagicMeleeException("Error deleting ability score array", ex);
        }
    }

    public async Task<AbilityScoreArrDTO> GetByCharacterIdAsync(int characterId)
    {
        try
        {
            var abilityScoreArr = await _abilityScoreArrRepo.GetByCharacterIdAsync(characterId);
            if (abilityScoreArr == null)
            {
                _logger.LogWarning("Ability score array not found for character ID: {CharacterId}", characterId);
                throw new CharacterNotFoundException($"Ability score array not found for character ID: {characterId}");
            }
            return AbilityScoreArrUtility.AbilityScoreArrToDTO(abilityScoreArr);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve ability score array for character ID: {CharacterId}", characterId);
            throw new MagicMeleeException("Error retrieving ability score array for character", ex);
        }
    }
}