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

public class CharacterRaceServiceTests
{
    private readonly Mock<ICharacterRaceRepo> _characterRaceRepoMock;
    private readonly Mock<ILogger<CharacterRaceService>> _loggerMock;
    private readonly CharacterRaceService _characterRaceService;

    public CharacterRaceServiceTests()
    {
        _characterRaceRepoMock = new Mock<ICharacterRaceRepo>();
        _loggerMock = new Mock<ILogger<CharacterRaceService>>();
        _characterRaceService = new CharacterRaceService(_characterRaceRepoMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCharacterRaceDTO_WhenCharacterRaceExists()
    {
        // Arrange
        var characterRace = new CharacterRace { CharacterRaceId = 1, Name = "Elf", Speed = 30 };
        _characterRaceRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(characterRace);

        // Act
        var result = await _characterRaceService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.CharacterRaceId);
        Assert.Equal("Elf", result.Name);
        Assert.Equal(30, result.Speed);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowCharacterNotFoundException_WhenCharacterRaceDoesNotExist()
    {
        // Arrange
        _characterRaceRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CharacterRace)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterRaceService.GetByIdAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfCharacterRaceDTOs()
    {
        // Arrange
        var characterRaces = new List<CharacterRace>
        {
            new CharacterRace { CharacterRaceId = 1, Name = "Elf", Speed = 30 },
            new CharacterRace { CharacterRaceId = 2, Name = "Dwarf", Speed = 25 }
        };
        _characterRaceRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(characterRaces);

        // Act
        var result = await _characterRaceService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddAsync_ShouldAddCharacterRaceSuccessfully()
    {
        // Arrange
        var characterRaceDto = new CharacterRaceDTO { CharacterRaceId = 1, Name = "Elf", Speed = 30 };

        // Act
        await _characterRaceService.AddAsync(characterRaceDto);

        // Assert
        _characterRaceRepoMock.Verify(repo => repo.AddAsync(It.IsAny<CharacterRace>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateCharacterRaceSuccessfully()
    {
        // Arrange
        var existingCharacterRace = new CharacterRace { CharacterRaceId = 1, Name = "Elf", Speed = 30 };
        var updatedCharacterRaceDto = new CharacterRaceDTO { CharacterRaceId = 1, Name = "Elf", Speed = 35 };
        _characterRaceRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingCharacterRace);

        // Act
        await _characterRaceService.UpdateAsync(updatedCharacterRaceDto);

        // Assert
        _characterRaceRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<CharacterRace>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowCharacterNotFoundException_WhenCharacterRaceDoesNotExist()
    {
        // Arrange
        var characterRaceDto = new CharacterRaceDTO { CharacterRaceId = 1, Name = "Elf", Speed = 30 };
        _characterRaceRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CharacterRace)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterRaceService.UpdateAsync(characterRaceDto));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteCharacterRaceSuccessfully()
    {
        // Arrange
        var characterRace = new CharacterRace { CharacterRaceId = 1, Name = "Elf", Speed = 30 };
        _characterRaceRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(characterRace);

        // Act
        await _characterRaceService.DeleteAsync(1);

        // Assert
        _characterRaceRepoMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowCharacterNotFoundException_WhenCharacterRaceDoesNotExist()
    {
        // Arrange
        _characterRaceRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CharacterRace)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterRaceService.DeleteAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetByCharacterIdAsync_ShouldReturnCharacterRaceDTO_WhenCharacterRaceExistsForCharacter()
    {
        // Arrange
        var characterRace = new CharacterRace { CharacterRaceId = 1, Name = "Elf", Speed = 30 };
        _characterRaceRepoMock.Setup(repo => repo.GetByCharacterIdAsync(1)).ReturnsAsync(characterRace);

        // Act
        var result = await _characterRaceService.GetByCharacterIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.CharacterRaceId);
        Assert.Equal("Elf", result.Name);
        Assert.Equal(30, result.Speed);
    }

    [Fact]
    public async Task GetByCharacterIdAsync_ShouldThrowCharacterNotFoundException_WhenCharacterRaceDoesNotExistForCharacter()
    {
        // Arrange
        _characterRaceRepoMock.Setup(repo => repo.GetByCharacterIdAsync(1)).ReturnsAsync((CharacterRace)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterRaceService.GetByCharacterIdAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }
}