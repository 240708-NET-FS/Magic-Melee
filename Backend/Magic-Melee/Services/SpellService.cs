using MagicMelee.Data;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;

namespace MagicMelee.Services;

public class SpellService : ISpellService
{
    private readonly ISpellRepo _spellRepo;
    private readonly ILogger<SpellService> _logger;

    public SpellService(ISpellRepo spellRepo, ILogger<SpellService> logger)
    {
        _spellRepo = spellRepo;
        _logger = logger;
    }

    public async Task<SpellDTO> GetByIdAsync(int id)
    {
        try
        {
            var spell = await _spellRepo.GetByIdAsync(id);
            if (spell == null)
            {
                _logger.LogWarning("Spell not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Spell not found with ID: {id}");
            }
            return SpellUtility.SpellToDTO(spell);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve spell by ID: {Id}", id);
            throw new MagicMeleeException("Error retrieving spell", ex);
        }
    }

    public async Task<IEnumerable<SpellDTO>> GetAllAsync()
    {
        try
        {
            var spells = await _spellRepo.GetAllAsync();
            return spells.Select(SpellUtility.SpellToDTO).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve all spells");
            throw new MagicMeleeException("Error retrieving all spells", ex);
        }
    }

    public async Task AddAsync(SpellDTO spellDto)
    {
        try
        {
            var spell = SpellUtility.DTOToSpell(spellDto);
            await _spellRepo.AddAsync(spell);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add spell: {SpellDto}", spellDto);
            throw new MagicMeleeException("Error adding spell", ex);
        }
    }

    public async Task UpdateAsync(SpellDTO spellDto)
    {
        try
        {
            var spell = await _spellRepo.GetByIdAsync(spellDto.SpellId);
            if (spell == null)
            {
                _logger.LogWarning("Spell not found with ID: {Id}", spellDto.SpellId);
                throw new CharacterNotFoundException($"Spell not found with ID: {spellDto.SpellId}");
            }

            spell = SpellUtility.DTOToSpell(spellDto);
            await _spellRepo.UpdateAsync(spell);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update spell: {SpellDto}", spellDto);
            throw new MagicMeleeException("Error updating spell", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var spell = await _spellRepo.GetByIdAsync(id);
            if (spell == null)
            {
                _logger.LogWarning("Spell not found with ID: {Id}", id);
                throw new CharacterNotFoundException($"Spell not found with ID: {id}");
            }

            await _spellRepo.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete spell by ID: {Id}", id);
            throw new MagicMeleeException("Error deleting spell", ex);
        }
    }
}