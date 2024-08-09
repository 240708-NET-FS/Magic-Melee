using Microsoft.AspNetCore.Mvc;
using MagicMelee.Services;
using MagicMelee.DTO;
using apiRaceController = MagicMelee.ApiUtil.Controller.RaceController; 
using apiRaceDTO=MagicMelee.ApiUtil.DTO.Races.RaceDTO;

namespace MagicMelee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterRaceController : ControllerBase
{
    private readonly ICharacterRaceService _characterRaceService;

    public CharacterRaceController(ICharacterRaceService characterRaceService)
    {
        _characterRaceService = characterRaceService;
    }

    // GET: api/CharacterRace/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var characterRace = await _characterRaceService.GetByIdAsync(id);
            if (characterRace == null)
            {
                return NotFound($"Character race not found with ID: {id}");
            }
            return Ok(characterRace);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/CharacterRace/character/{characterId}
    [HttpGet("character/{characterId}")]
    public async Task<IActionResult> GetByCharacterId(int characterId)
    {
        try
        {
            var characterRace = await _characterRaceService.GetByCharacterIdAsync(characterId);
            if (characterRace == null)
            {
                return NotFound($"Character race not found for character ID: {characterId}");
            }
            return Ok(characterRace);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/CharacterRace
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var characterRaces = await _characterRaceService.GetAllAsync();
            return Ok(characterRaces);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST: api/CharacterRace
    // add all races to DB 
    [HttpPost]
    public async Task<IActionResult> Add()
    {
        try
        {
           List<apiRaceDTO> raceDTOs = await apiRaceController.GetAllRaces();
           int addedCount = 0;
           foreach(apiRaceDTO apiRace in raceDTOs) {
            CharacterRaceDTO raceDTO = new(){
                Name = apiRace.Name,
                Speed = apiRace.Speed
            }; 
            await _characterRaceService.AddAsync(raceDTO);
            addedCount++;
           }
            return Ok(new { message = $"{addedCount} character races added successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/CharacterRace/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CharacterRaceDTO characterRaceDto)
    {
        if (id != characterRaceDto.CharacterRaceId)
        {
            return BadRequest("ID mismatch");
        }

        try
        {
            await _characterRaceService.UpdateAsync(characterRaceDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/CharacterRace/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _characterRaceService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}