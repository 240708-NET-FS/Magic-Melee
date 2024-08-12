using Microsoft.AspNetCore.Mvc;
using MagicMelee.Services;
using MagicMelee.DTO;

namespace MagicMelee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly ISkillsService _skillsService;

    public SkillsController(ISkillsService skillsService)
    {
        _skillsService = skillsService;
    }

    // GET: api/Skills/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var skills = await _skillsService.GetByIdAsync(id);
            if (skills == null)
            {
                return NotFound($"Skills not found with ID: {id}");
            }
            return Ok(skills);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Skills/character/{characterId}
    [HttpGet("character/{characterId}")]
    public async Task<IActionResult> GetByCharacterId(int characterId)
    {
        try
        {
            var skills = await _skillsService.GetByCharacterIdAsync(characterId);
            if (skills == null)
            {
                return NotFound($"Skills not found for character ID: {characterId}");
            }
            return Ok(skills);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Skills
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var skills = await _skillsService.GetAllAsync();
            return Ok(skills);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST: api/Skills
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] SkillsDTO skillsDto)
    {
        try
        {
            int ID = await _skillsService.AddAsync(skillsDto);
            skillsDto.SkillsId = ID; 
            return CreatedAtAction(nameof(GetById), new { id = ID }, skillsDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/Skills/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SkillsDTO skillsDto)
    {
        if (id != skillsDto.SkillsId)
        {
            return BadRequest("ID mismatch");
        }

        try
        {
            
            await _skillsService.UpdateAsync(skillsDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/Skills/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _skillsService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}