using MagicMelee.Services;
using MagicMelee.Data;
using MagicMelee.Models;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MagicMelee.Tests;

public class UserServiceTests
{
    private readonly Mock<IUserRepo> _userRepoMock;
    private readonly Mock<ILogger<UserService>> _loggerMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userRepoMock = new Mock<IUserRepo>();
        _loggerMock = new Mock<ILogger<UserService>>();
        _userService = new UserService(_userRepoMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUserDTO_WhenUserExists()
    {
        // Arrange
        var user = new User { Id = 1, FirstName = "John", LastName = "Doe" };
        _userRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

        // Act
        var result = await _userService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.LastName);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowMagicMeleeException_WhenUserDoesNotExist()
    {
        // Arrange
        _userRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((User)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _userService.GetByIdAsync(1));
        Assert.IsType<UserNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfUserDTOs()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe" },
            new User { Id = 2, FirstName = "Jane", LastName = "Smith" }
        };
        _userRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

        // Act
        var result = await _userService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddAsync_ShouldAddUserSuccessfully()
    {
        // Arrange
        var userDto = new UserDTO { Id = 1, FirstName = "John", LastName = "Doe" };

        // Act
        await _userService.AddAsync(userDto);

        // Assert
        _userRepoMock.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateUserSuccessfully()
    {
        // Arrange
        var existingUser = new User { Id = 1, FirstName = "John", LastName = "Doe" };
        var updatedUserDto = new UserDTO { Id = 1, FirstName = "Jane", LastName = "Smith" };
        _userRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingUser);

        // Act
        await _userService.UpdateAsync(updatedUserDto);

        // Assert
        _userRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowMagicMeleeException_WhenUserDoesNotExist()
    {
        // Arrange
        var userDto = new UserDTO { Id = 1, FirstName = "John", LastName = "Doe" };
        _userRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((User)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _userService.UpdateAsync(userDto));
        Assert.IsType<UserNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteUserSuccessfully()
    {
        // Arrange
        var user = new User { Id = 1, FirstName = "John", LastName = "Doe" };
        _userRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

        // Act
        await _userService.DeleteAsync(1);

        // Assert
        _userRepoMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowMagicMeleeException_WhenUserDoesNotExist()
    {
        // Arrange
        _userRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((User)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _userService.DeleteAsync(1));
        Assert.IsType<UserNotFoundException>(exception.InnerException);
    }
}