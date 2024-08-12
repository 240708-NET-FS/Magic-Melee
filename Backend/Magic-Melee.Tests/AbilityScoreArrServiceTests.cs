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

public class AbilityScoreArrServiceTests
{
    private readonly Mock<IAbilityScoreArrRepo> _abilityScoreArrRepoMock;
    private readonly Mock<ILogger<AbilityScoreArrService>> _loggerMock;
    private readonly AbilityScoreArrService _abilityScoreArrService;

    public AbilityScoreArrServiceTests()
    {
        _abilityScoreArrRepoMock = new Mock<IAbilityScoreArrRepo>();
        _loggerMock = new Mock<ILogger<AbilityScoreArrService>>();
        _abilityScoreArrService = new AbilityScoreArrService(_abilityScoreArrRepoMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnAbilityScoreArrDTO_WhenAbilityScoreArrExists()
    {
        // Arrange
        var abilityScoreArr = new AbilityScoreArr { AbilityScoreArrId = 1, Str = 15, Dex = 14, Con = 13, Int = 12, Wis = 10, Cha = 8 };
        _abilityScoreArrRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(abilityScoreArr);

        // Act
        var result = await _abilityScoreArrService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.AbilityScoreArrId);
        Assert.Equal(15, result.Str);
        Assert.Equal(14, result.Dex);
        Assert.Equal(13, result.Con);
        Assert.Equal(12, result.Int);
        Assert.Equal(10, result.Wis);
        Assert.Equal(8, result.Cha);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowCharacterNotFoundException_WhenAbilityScoreArrDoesNotExist()
    {
        // Arrange
        _abilityScoreArrRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((AbilityScoreArr)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _abilityScoreArrService.GetByIdAsync(1));

        // Check if the InnerException is of type CharacterNotFoundException
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfAbilityScoreArrDTOs()
    {
        // Arrange
        var abilityScoreArrs = new List<AbilityScoreArr>
        {
            new AbilityScoreArr { AbilityScoreArrId = 1, Str = 15, Dex = 14, Con = 13, Int = 12, Wis = 10, Cha = 8 },
            new AbilityScoreArr { AbilityScoreArrId = 2, Str = 18, Dex = 16, Con = 14, Int = 13, Wis = 11, Cha = 9 }
        };
        _abilityScoreArrRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(abilityScoreArrs);

        // Act
        var result = await _abilityScoreArrService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddAsync_ShouldAddAbilityScoreArrSuccessfully()
    {
        // Arrange
        var abilityScoreArrDto = new AbilityScoreArrDTO { AbilityScoreArrId = 1, Str = 15, Dex = 14, Con = 13, Int = 12, Wis = 10, Cha = 8 };

        // Act
        await _abilityScoreArrService.AddAsync(abilityScoreArrDto);

        // Assert
        _abilityScoreArrRepoMock.Verify(repo => repo.AddAsync(It.IsAny<AbilityScoreArr>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateAbilityScoreArrSuccessfully()
    {
        // Arrange
        var existingAbilityScoreArr = new AbilityScoreArr { AbilityScoreArrId = 1, Str = 15, Dex = 14, Con = 13, Int = 12, Wis = 10, Cha = 8 };
        var updatedAbilityScoreArrDto = new AbilityScoreArrDTO { AbilityScoreArrId = 1, Str = 18, Dex = 16, Con = 14, Int = 13, Wis = 11, Cha = 9 };
        _abilityScoreArrRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingAbilityScoreArr);

        // Act
        await _abilityScoreArrService.UpdateAsync(updatedAbilityScoreArrDto);

        // Assert
        _abilityScoreArrRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<AbilityScoreArr>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowCharacterNotFoundException_WhenAbilityScoreArrDoesNotExist()
    {
        // Arrange
        var abilityScoreArrDto = new AbilityScoreArrDTO { AbilityScoreArrId = 1 };
        _abilityScoreArrRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((AbilityScoreArr)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _abilityScoreArrService.UpdateAsync(abilityScoreArrDto));

        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteAbilityScoreArrSuccessfully()
    {
        // Arrange
        var abilityScoreArr = new AbilityScoreArr { AbilityScoreArrId = 1, Str = 15, Dex = 14, Con = 13, Int = 12, Wis = 10, Cha = 8 };
        _abilityScoreArrRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(abilityScoreArr);

        // Act
        await _abilityScoreArrService.DeleteAsync(1);

        // Assert
        _abilityScoreArrRepoMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowCharacterNotFoundException_WhenAbilityScoreArrDoesNotExist()
    {
        // Arrange
        _abilityScoreArrRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((AbilityScoreArr)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _abilityScoreArrService.DeleteAsync(1));

        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetByCharacterIdAsync_ShouldReturnAbilityScoreArrDTO_WhenAbilityScoreArrExistsForCharacter()
    {
        // Arrange
        var abilityScoreArr = new AbilityScoreArr { AbilityScoreArrId = 1, Str = 15, Dex = 14, Con = 13, Int = 12, Wis = 10, Cha = 8 };
        _abilityScoreArrRepoMock.Setup(repo => repo.GetByCharacterIdAsync(1)).ReturnsAsync(abilityScoreArr);

        // Act
        var result = await _abilityScoreArrService.GetByCharacterIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.AbilityScoreArrId);
        Assert.Equal(15, result.Str);
        Assert.Equal(14, result.Dex);
        Assert.Equal(13, result.Con);
        Assert.Equal(12, result.Int);
        Assert.Equal(10, result.Wis);
        Assert.Equal(8, result.Cha);
    }

    [Fact]
    public async Task GetByCharacterIdAsync_ShouldThrowCharacterNotFoundException_WhenAbilityScoreArrDoesNotExistForCharacter()
    {
        // Arrange
        _abilityScoreArrRepoMock.Setup(repo => repo.GetByCharacterIdAsync(1)).ReturnsAsync((AbilityScoreArr)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _abilityScoreArrService.GetByCharacterIdAsync(1));

        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }
}