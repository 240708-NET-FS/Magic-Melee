using MagicMelee.Data;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;

namespace MagicMelee.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepo userRepo, ILogger<UserService> logger)
    {
        _userRepo = userRepo;
        _logger = logger;
    }

    public async Task<UserDTO> GetByIdAsync(int id)
    {
        try
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User not found with ID: {Id}", id);
                throw new UserNotFoundException($"User not found with ID: {id}");
            }
            return UserUtility.UserToDTO(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve user by ID: {Id}", id);
            throw new MagicMeleeException("Error retrieving user", ex);
        }
    }

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        try
        {
            var users = await _userRepo.GetAllAsync();
            return users.Select(user => UserUtility.UserToDTO(user)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve all users");
            throw new MagicMeleeException("Error retrieving all users", ex);
        }
    }

    public async Task AddAsync(UserDTO userDto)
    {
        try
        {
            var user = UserUtility.DTOToUser(userDto);
            await _userRepo.AddAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add user: {User}", userDto);
            throw new MagicMeleeException("Error adding user", ex);
        }
    }

    public async Task UpdateAsync(UserDTO userDto)
    {
        try
        {
            var user = await _userRepo.GetByIdAsync(userDto.UserId);
            if (user == null)
            {
                _logger.LogWarning("User not found with ID: {Id}", userDto.UserId);
                throw new UserNotFoundException($"User not found with ID: {userDto.UserId}");
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;

            await _userRepo.UpdateAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update user: {User}", userDto);
            throw new MagicMeleeException("Error updating user", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User not found with ID: {Id}", id);
                throw new UserNotFoundException($"User not found with ID: {id}");
            }

            await _userRepo.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete user by ID: {Id}", id);
            throw new MagicMeleeException("Error deleting user", ex);
        }
    }
}