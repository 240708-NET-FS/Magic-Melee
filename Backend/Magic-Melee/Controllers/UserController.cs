using Microsoft.AspNetCore.Mvc;
using MagicMelee.Services;
using MagicMelee.DTO;

namespace MagicMelee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/User/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

        try
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);  // Consider more specific error handling
        }
    }

    // GET: api/User
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // POST: api/User
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserDTO userDto)
    {
        try
        {
            await _userService.AddAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserDTO userDto)
    {
        if (id != userDto.Id)
        {
            return BadRequest("ID mismatch");
        }

        try
        {
            await _userService.UpdateAsync(userDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // DELETE: api/User/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}