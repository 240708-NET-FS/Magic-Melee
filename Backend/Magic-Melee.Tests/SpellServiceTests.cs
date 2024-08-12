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

public class SpellServiceTests
{
    private readonly Mock<ISpellRepo> _spellRepoMock;
    private readonly Mock<ILogger<SpellService>> _loggerMock;
    private readonly SpellService _spellService;

    public SpellServiceTests()
    {
        _spellRepoMock = new Mock<ISpellRepo>();
        _loggerMock = new Mock<ILogger<SpellService>>();
        _spellService = new SpellService(_spellRepoMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnSpellDTO_WhenSpellExists()
    {
        // Arrange
        var spell = new Spell { SpellId = 1, SpellName = "Fireball", SpellLevel = 3 };
        _spellRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(spell);

        // Act
        var result = await _spellService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.SpellId);
        Assert.Equal("Fireball", result.SpellName);
        Assert.Equal(3, result.SpellLevel);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowMagicMeleeException_WhenSpellDoesNotExist()
    {
        // Arrange
        _spellRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Spell)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _spellService.GetByIdAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfSpellDTOs()
    {
        // Arrange
        var spells = new List<Spell>
        {
            new Spell { SpellId = 1, SpellName = "Fireball", SpellLevel = 3 },
            new Spell { SpellId = 2, SpellName = "Ice Storm", SpellLevel = 4 }
        };
        _spellRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(spells);

        // Act
        var result = await _spellService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddAsync_ShouldAddSpellSuccessfully()
    {
        // Arrange
        var spellDto = new SpellDTO { SpellId = 1, SpellName = "Fireball", SpellLevel = 3 };

        // Act
        await _spellService.AddAsync(spellDto);

        // Assert
        _spellRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Spell>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateSpellSuccessfully()
    {
        // Arrange
        var existingSpell = new Spell { SpellId = 1, SpellName = "Fireball", SpellLevel = 3 };
        var updatedSpellDto = new SpellDTO { SpellId = 1, SpellName = "Ice Storm", SpellLevel = 4 };
        _spellRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingSpell);

        // Act
        await _spellService.UpdateAsync(updatedSpellDto);

        // Assert
        _spellRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<Spell>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowMagicMeleeException_WhenSpellDoesNotExist()
    {
        // Arrange
        var spellDto = new SpellDTO { SpellId = 1, SpellName = "Ice Storm", SpellLevel = 4 };
        _spellRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Spell)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _spellService.UpdateAsync(spellDto));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteSpellSuccessfully()
    {
        // Arrange
        var spell = new Spell { SpellId = 1, SpellName = "Fireball", SpellLevel = 3 };
        _spellRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(spell);

        // Act
        await _spellService.DeleteAsync(1);

        // Assert
        _spellRepoMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowMagicMeleeException_WhenSpellDoesNotExist()
    {
        // Arrange
        _spellRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Spell)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _spellService.DeleteAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }
}