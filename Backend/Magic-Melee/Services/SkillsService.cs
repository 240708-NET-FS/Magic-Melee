using MagicMelee.Data;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;

namespace MagicMelee.Services;

public class SkillsService : ISkillsService
{
    private readonly ISkillsRepo _skillsRepo;
    private readonly ILogger<SkillsService> _logger;

    public SkillsService(ISkillsRepo skillsRepo, ILogger<SkillsService> logger)
    {
        _skillsRepo = skillsRepo;
        _logger = logger;
    }

    public async Task<SkillsDTO> GetByIdAsync(int id)
    {
        try
        {
            var skills = await _skillsRepo.GetByIdAsync(id);
            if (skills == null)
            {
                _logger.LogWarning("Skills not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Skills not found with ID: {id}");
            }
            return SkillsUtility.SkillsToDTO(skills);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve skills by ID: {Id}", id);
            throw new MagicMeleeException("Error retrieving skills", ex);
        }
    }

    public async Task<IEnumerable<SkillsDTO>> GetAllAsync()
    {
        try
        {
            var skills = await _skillsRepo.GetAllAsync();
            return skills.Select(SkillsUtility.SkillsToDTO).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve all skills");
            throw new MagicMeleeException("Error retrieving all skills", ex);
        }
    }

    public async Task AddAsync(SkillsDTO skillsDto)
    {
        try
        {
            var skills = SkillsUtility.DTOToSkills(skillsDto);
            await _skillsRepo.AddAsync(skills);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add skills: {SkillsDto}", skillsDto);
            throw new MagicMeleeException("Error adding skills", ex);
        }
    }

    public async Task UpdateAsync(SkillsDTO skillsDto)
    {
        try
        {
            var skills = await _skillsRepo.GetByIdAsync(skillsDto.SkillsId);
            if (skills == null)
            {
                _logger.LogWarning("Skills not found with ID: {Id}", skillsDto.SkillsId);
                throw new CharacterNotFoundException($"Skills not found with ID: {skillsDto.SkillsId}");
            }

            //skills = SkillsUtility.DTOToSkills(skillsDto); // Updating fields from DTO
            skills.Athletics = skillsDto.Athletics;
            skills.Acrobatics = skillsDto.Acrobatics;
            skills.SleightOfHand = skillsDto.SleightOfHand;
            skills.Stealth = skillsDto.Stealth;
            skills.Deception = skillsDto.Deception;
            skills.AnimalHandling = skillsDto.AnimalHandling;
            skills.Survival = skillsDto.Survival;
            skills.History = skillsDto.History;
            skills.Religion = skillsDto.Religion;
            skills.Medicine = skillsDto.Medicine;
            skills.Perception = skillsDto.Perception;
            skills.Insight = skillsDto.Insight;
            skills.Performance = skillsDto.Performance;
            skills.Intimidation = skillsDto.Intimidation;
            skills.Persuasion = skillsDto.Persuasion;
            skills.Arcana = skillsDto.Arcana;
            skills.Investigation = skillsDto.Investigation;
            skills.Nature = skillsDto.Nature;
            await _skillsRepo.UpdateAsync(skills);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update skills: {SkillsDto}", skillsDto);
            throw new MagicMeleeException("Error updating skills", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var skills = await _skillsRepo.GetByIdAsync(id);
            if (skills == null)
            {
                _logger.LogWarning("Skills not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Skills not found with ID: {id}");
            }

            await _skillsRepo.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete skills by ID: {Id}", id);
            throw new MagicMeleeException("Error deleting skills", ex);
        }
    }

    public async Task<SkillsDTO> GetByCharacterIdAsync(int characterId)
    {
        try
        {
            var skills = await _skillsRepo.GetByCharacterIdAsync(characterId);
            if (skills == null)
            {
                _logger.LogWarning("Skills not found for character ID: {CharacterId}", characterId);
                throw new CharacterNotFoundException($"Skills not found for character ID: {characterId}");
            }
            return SkillsUtility.SkillsToDTO(skills);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve skills for character ID: {CharacterId}", characterId);
            throw new MagicMeleeException("Error retrieving skills for character", ex);
        }
    }
}