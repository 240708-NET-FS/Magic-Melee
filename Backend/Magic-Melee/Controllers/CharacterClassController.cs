using Microsoft.AspNetCore.Mvc;
using MagicMelee.Services;
using MagicMelee.DTO;
using apiClassController=MagicMelee.ApiUtil.Controller.ClassController;
using apiClassDTO=MagicMelee.ApiUtil.DTO.Classes.ClassDTO;

namespace MagicMelee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterClassController : ControllerBase
{
    private readonly ICharacterClassService _characterClassService;

    public CharacterClassController(ICharacterClassService characterClassService)
    {
        _characterClassService = characterClassService;
    }

    // GET: api/CharacterClass/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var characterClass = await _characterClassService.GetByIdAsync(id);
            if (characterClass == null)
            {
                return NotFound($"Character class not found with ID: {id}");
            }
            return Ok(characterClass);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/CharacterClass
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var characterClasses = await _characterClassService.GetAllAsync();
            return Ok(characterClasses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST: api/CharacterClass
    [HttpPost]
    public async Task<IActionResult> Add()
    {
        try
        {
            List<apiClassDTO> classDTOs = await apiClassController.GetAllClasses();
            foreach(apiClassDTO classDTO in classDTOs) {
                CharacterClassDTO characterClassDTO = new() {
                    Name=classDTO.Name
                };
                await _characterClassService.AddAsync(characterClassDTO);
            }

            return Created(); // CreatedAtAction("created all classes", classDTOs);

            
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/CharacterClass/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CharacterClassDTO characterClassDto)
    {
        if (id != characterClassDto.CharacterClassId)
        {
            return BadRequest("ID mismatch");
        }

        try
        {
            await _characterClassService.UpdateAsync(characterClassDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/CharacterClass/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _characterClassService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}