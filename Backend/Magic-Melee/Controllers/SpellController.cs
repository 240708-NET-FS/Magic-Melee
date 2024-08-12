using Microsoft.AspNetCore.Mvc;
using MagicMelee.Services;
using MagicMelee.DTO;
using apiSpellDTO=MagicMelee.ApiUtil.DTO.Spells.SpellEntityDTO;


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

    // GET: api/Spell/class/{name}
    [HttpGet("class/{name}")]
    public async Task<IActionResult> GetAll(string name )
    {
        try
        {
            List<apiSpellDTO> spells = await MagicMelee.ApiUtil.Controller.SpellController.GetSpellsByClass(name);
            List<SpellDTO> spellDTOs = []; 
            foreach(apiSpellDTO spell in spells) {
                spellDTOs.Add(new() {
                    SpellId= (await _spellService.GetByNameAsync(spell.Name)).SpellId,
                    SpellName = spell.Name,
                    SpellRange=spell.Range,
                    SpellLevel =spell.Level,
                    SpellDamageType=spell.DamageType
                });
            }
            return Ok(spellDTOs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST: api/Spell
    // this will now post all spells to the database. 
    [HttpPost]
    public async Task<IActionResult> Add()
    {
        try
        {
            
            List<apiSpellDTO> spellDTOs =  await MagicMelee.ApiUtil.Controller.SpellController.GetAllSpells();
            int addedCount = 0;
            foreach (apiSpellDTO aSpellDTO in spellDTOs) {
                SpellDTO spellDTO = new()
                {
                    SpellLevel = aSpellDTO.Level,
                    SpellDamageType = aSpellDTO.DamageType,
                    SpellName = aSpellDTO.Name,
                    SpellRange = aSpellDTO.Range
                };
                await _spellService.AddAsync(spellDTO);
                addedCount++;
            }
            return Ok(new { message = $"{addedCount} spells added successfully." });
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