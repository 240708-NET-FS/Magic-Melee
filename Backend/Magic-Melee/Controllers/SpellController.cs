using Microsoft.AspNetCore.Mvc;
using MagicMelee.Services;
using MagicMelee.DTO;

namespace MagicMelee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpellController : ControllerBase
{
    private readonly ISpellService _spellService;

    public SpellController(ISpellService spellService)
    {
        _spellService = spellService;
    }

    // GET: api/Spell/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var spell = await _spellService.GetByIdAsync(id);
            if (spell == null)
            {
                return NotFound($"Spell not found with ID: {id}");
            }
            return Ok(spell);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Spell
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var spells = await _spellService.GetAllAsync();
            return Ok(spells);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST: api/Spell
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] SpellDTO spellDto)
    {
        try
        {
            await _spellService.AddAsync(spellDto);
            return CreatedAtAction(nameof(GetById), new { id = spellDto.SpellId }, spellDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/Spell/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SpellDTO spellDto)
    {
        if (id != spellDto.SpellId)
        {
            return BadRequest("ID mismatch");
        }

        try
        {
            await _spellService.UpdateAsync(spellDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/Spell/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _spellService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}