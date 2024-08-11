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

public class DndCharacterServiceTests
{
    private readonly Mock<IDndCharacterRepo> _mockCharacterRepo;
    private readonly Mock<ICharacterSpellRepo> _mockCharacterSpellRepo;
    private readonly Mock<ILogger<DndCharacterService>> _mockLogger;
    private readonly DndCharacterService _characterService;

    public DndCharacterServiceTests()
    {
        _mockCharacterRepo = new Mock<IDndCharacterRepo>();
        _mockCharacterSpellRepo = new Mock<ICharacterSpellRepo>();
        _mockLogger = new Mock<ILogger<DndCharacterService>>();
        _characterService = new DndCharacterService(_mockCharacterRepo.Object, _mockCharacterSpellRepo.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task GetByIdAsync_CharacterExists_ReturnsCharacter()
    {
        // Arrange
        var characterId = 1;
        var character = new DndCharacter { CharacterId = characterId, CharacterName = "Test Character" };
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterId)).ReturnsAsync(character);

        // Act
        var result = await _characterService.GetByIdAsync(characterId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(characterId, result.CharacterId);
    }

    [Fact]
    public async Task GetByIdAsync_CharacterDoesNotExist_ThrowsCharacterNotFoundException()
    {
        // Arrange
        var characterId = 1;
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterId)).ReturnsAsync((DndCharacter?)null);

        // Act & Assert
        await Assert.ThrowsAsync<CharacterNotFoundException>(() => _characterService.GetByIdAsync(characterId));
    }

    [Fact]
    public async Task GetByUserIdAsync_UserHasCharacters_ReturnsCharacters()
    {
        // Arrange
        var userId = 1;
        var characters = new List<DndCharacter>
        {
            new DndCharacter { CharacterId = 1, CharacterName = "Character 1", UserId = userId },
            new DndCharacter { CharacterId = 2, CharacterName = "Character 2", UserId = userId }
        };
        _mockCharacterRepo.Setup(repo => repo.GetByUserId(userId)).ReturnsAsync(characters);

        // Act
        var result = await _characterService.GetByUserIdAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetAllAsync_CharactersExist_ReturnsAllCharacters()
    {
        // Arrange
        var characters = new List<DndCharacter>
        {
            new DndCharacter { CharacterId = 1, CharacterName = "Character 1" },
            new DndCharacter { CharacterId = 2, CharacterName = "Character 2" }
        };
        _mockCharacterRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(characters);

        // Act
        var result = await _characterService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddAsync_ValidCharacter_AddsCharacter()
    {
        // Arrange
        var characterDto = new DndCharacterDTO { CharacterId = 1, CharacterName = "New Character" };
        var character = DndCharacterUtility.DTOToDndCharacter(characterDto);

        // Act
        await _characterService.AddAsync(characterDto);

        // Assert
        _mockCharacterRepo.Verify(repo => repo.AddAsync(It.IsAny<DndCharacter>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_CharacterExists_UpdatesCharacter()
    {
        // Arrange
        var characterId = 1;
        var characterDto = new DndCharacterDTO { CharacterId = characterId, CharacterName = "Updated Character" };
        var character = new DndCharacter { CharacterId = characterId, CharacterName = "Original Character" };
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterId)).ReturnsAsync(character);

        // Act
        await _characterService.UpdateAsync(characterDto);

        // Assert
        _mockCharacterRepo.Verify(repo => repo.UpdateAsync(It.IsAny<DndCharacter>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_CharacterExists_DeletesCharacter()
    {
        // Arrange
        var characterId = 1;
        var character = new DndCharacter { CharacterId = characterId, CharacterName = "Character to Delete" };
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterId)).ReturnsAsync(character);

        // Act
        await _characterService.DeleteAsync(characterId);

        // Assert
        _mockCharacterRepo.Verify(repo => repo.DeleteAsync(characterId), Times.Once);
    }

    [Fact]
    public async Task GetCharacterSpellsAsync_CharacterHasSpells_ReturnsSpells()
    {
        // Arrange
        var characterId = 1;
        var characterSpells = new List<CharacterSpell>
        {
            new CharacterSpell { CharacterId = characterId, SpellId = 1, Spell = new Spell { SpellId = 1, SpellName = "Spell 1" } },
            new CharacterSpell { CharacterId = characterId, SpellId = 2, Spell = new Spell { SpellId = 2, SpellName = "Spell 2" } }
        };
        _mockCharacterSpellRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(characterSpells);

        // Act
        var result = await _characterService.GetCharacterSpellsAsync(characterId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddSpellToCharacterAsync_ValidSpell_AddsSpellToCharacter()
    {
        // Arrange
        var characterId = 1;
        var spellId = 1;

        // Act
        await _characterService.AddSpellToCharacterAsync(characterId, spellId);

        // Assert
        _mockCharacterSpellRepo.Verify(repo => repo.AddAsync(It.IsAny<CharacterSpell>()), Times.Once);
    }

    [Fact]
    public async Task RemoveSpellFromCharacterAsync_ValidSpell_RemovesSpellFromCharacter()
    {
        // Arrange
        var characterId = 1;
        var spellId = 1;

        // Act
        await _characterService.RemoveSpellFromCharacterAsync(characterId, spellId);

        // Assert
        _mockCharacterSpellRepo.Verify(repo => repo.DeleteAsync(characterId, spellId), Times.Once);
    }
}