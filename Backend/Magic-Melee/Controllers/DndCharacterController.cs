using Microsoft.AspNetCore.Mvc;
using MagicMelee.Services;
using MagicMelee.DTO;

namespace MagicMelee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DndCharacterController : ControllerBase
{
    private readonly IDndCharacterService _dndCharacterService;

    public DndCharacterController(IDndCharacterService dndCharacterService)
    {
        _dndCharacterService = dndCharacterService;
    }

    // GET: api/DndCharacter/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var character = await _dndCharacterService.GetByIdAsync(id);
            return Ok(character);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // GET: api/DndCharacter/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetCharactersByUserId(int userId)
    {
        try
        {
            var characters = await _dndCharacterService.GetByUserIdAsync(userId);
            if (!characters.Any())
            {
                return NotFound($"No characters found for user ID {userId}.");
            }
            return Ok(characters);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // GET: api/DndCharacter
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var characters = await _dndCharacterService.GetAllAsync();
        return Ok(characters);
    }

    // POST: api/DndCharacter
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] DndCharacterDTO characterDTO)
    {
        await _dndCharacterService.AddAsync(characterDTO);
        return CreatedAtAction(nameof(GetById), new { id = characterDTO.CharacterId }, characterDTO);
    }

    // PUT: api/DndCharacter/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DndCharacterDTO characterDTO)
    {
        if (id != characterDTO.CharacterId)
        {
            return BadRequest("ID mismatch");
        }

        try
        {
            await _dndCharacterService.UpdateAsync(characterDTO);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // DELETE: api/DndCharacter/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _dndCharacterService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}