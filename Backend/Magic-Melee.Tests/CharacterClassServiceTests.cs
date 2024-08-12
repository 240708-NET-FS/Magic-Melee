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

public class CharacterClassServiceTests
{
    private readonly Mock<ICharacterClassRepo> _characterClassRepoMock;
    private readonly Mock<ILogger<CharacterClassService>> _loggerMock;
    private readonly CharacterClassService _characterClassService;

    public CharacterClassServiceTests()
    {
        _characterClassRepoMock = new Mock<ICharacterClassRepo>();
        _loggerMock = new Mock<ILogger<CharacterClassService>>();
        _characterClassService = new CharacterClassService(_characterClassRepoMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCharacterClassDTO_WhenCharacterClassExists()
    {
        // Arrange
        var characterClass = new CharacterClass { CharacterClassId = 1, Name = "Warrior" };
        _characterClassRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(characterClass);

        // Act
        var result = await _characterClassService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.CharacterClassId);
        Assert.Equal("Warrior", result.Name);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowMagicMeleeException_WhenCharacterClassDoesNotExist()
    {
        // Arrange
        _characterClassRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CharacterClass)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterClassService.GetByIdAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfCharacterClassDTOs()
    {
        // Arrange
        var characterClasses = new List<CharacterClass>
        {
            new CharacterClass { CharacterClassId = 1, Name = "Warrior" },
            new CharacterClass { CharacterClassId = 2, Name = "Mage" }
        };
        _characterClassRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(characterClasses);

        // Act
        var result = await _characterClassService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddAsync_ShouldAddCharacterClassSuccessfully()
    {
        // Arrange
        var characterClassDto = new CharacterClassDTO { CharacterClassId = 1, Name = "Warrior" };

        // Act
        await _characterClassService.AddAsync(characterClassDto);

        // Assert
        _characterClassRepoMock.Verify(repo => repo.AddAsync(It.IsAny<CharacterClass>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateCharacterClassSuccessfully()
    {
        // Arrange
        var existingCharacterClass = new CharacterClass { CharacterClassId = 1, Name = "Warrior" };
        var updatedCharacterClassDto = new CharacterClassDTO { CharacterClassId = 1, Name = "Paladin" };
        _characterClassRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingCharacterClass);

        // Act
        await _characterClassService.UpdateAsync(updatedCharacterClassDto);

        // Assert
        _characterClassRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<CharacterClass>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowMagicMeleeException_WhenCharacterClassDoesNotExist()
    {
        // Arrange
        var characterClassDto = new CharacterClassDTO { CharacterClassId = 1, Name = "Paladin" };
        _characterClassRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CharacterClass)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterClassService.UpdateAsync(characterClassDto));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteCharacterClassSuccessfully()
    {
        // Arrange
        var characterClass = new CharacterClass { CharacterClassId = 1, Name = "Warrior" };
        _characterClassRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(characterClass);

        // Act
        await _characterClassService.DeleteAsync(1);

        // Assert
        _characterClassRepoMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowMagicMeleeException_WhenCharacterClassDoesNotExist()
    {
        // Arrange
        _characterClassRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CharacterClass)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterClassService.DeleteAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }
}