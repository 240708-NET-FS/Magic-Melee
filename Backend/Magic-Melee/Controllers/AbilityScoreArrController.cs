using Microsoft.AspNetCore.Mvc;
using MagicMelee.Services;
using MagicMelee.DTO;

namespace MagicMelee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AbilityScoreArrController : ControllerBase
{
    private readonly IAbilityScoreArrService _abilityScoreArrService;

    public AbilityScoreArrController(IAbilityScoreArrService abilityScoreArrService)
    {
        _abilityScoreArrService = abilityScoreArrService;
    }

    // GET: api/AbilityScoreArr/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var abilityScoreArr = await _abilityScoreArrService.GetByIdAsync(id);
            if (abilityScoreArr == null)
            {
                return NotFound($"Ability score array not found with ID: {id}");
            }
            return Ok(abilityScoreArr);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/AbilityScoreArr/character/{characterId}
    [HttpGet("character/{characterId}")]
    public async Task<IActionResult> GetByCharacterId(int characterId)
    {
        try
        {
            var abilityScoreArr = await _abilityScoreArrService.GetByCharacterIdAsync(characterId);
            if (abilityScoreArr == null)
            {
                return NotFound($"Ability score array not found for character ID: {characterId}");
            }
            return Ok(abilityScoreArr);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/AbilityScoreArr
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var abilityScoreArrs = await _abilityScoreArrService.GetAllAsync();
            return Ok(abilityScoreArrs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST: api/AbilityScoreArr
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AbilityScoreArrDTO abilityScoreArrDto)
    {
        try
        {
            int ID = await _abilityScoreArrService.AddAsync(abilityScoreArrDto);
            abilityScoreArrDto.AbilityScoreArrId = ID; 
            return CreatedAtAction(nameof(GetById), new { id = ID }, abilityScoreArrDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/AbilityScoreArr/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AbilityScoreArrDTO abilityScoreArrDto)
    {
        if (id != abilityScoreArrDto.AbilityScoreArrId)
        {
            return BadRequest("ID mismatch");
        }

        try
        {
            await _abilityScoreArrService.UpdateAsync(abilityScoreArrDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/AbilityScoreArr/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _abilityScoreArrService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}