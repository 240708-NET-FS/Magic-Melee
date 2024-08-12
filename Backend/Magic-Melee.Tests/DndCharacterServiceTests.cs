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
        var characterId = 1;
        var character = new DndCharacter { CharacterId = characterId, CharacterName = "Test Character" };
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterId)).ReturnsAsync(character);

        var result = await _characterService.GetByIdAsync(characterId);

        Assert.NotNull(result);
        Assert.Equal(characterId, result.CharacterId);
    }

    [Fact]
    public async Task GetByIdAsync_CharacterDoesNotExist_ThrowsCharacterNotFoundException()
    {
        var characterId = 1;
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterId)).ReturnsAsync((DndCharacter?)null);

        await Assert.ThrowsAsync<CharacterNotFoundException>(() => _characterService.GetByIdAsync(characterId));
    }

    [Fact]
    public async Task GetByUserIdAsync_UserHasNoCharacters_ReturnsEmptyList()
    {
        var userId = 1;
        _mockCharacterRepo.Setup(repo => repo.GetByUserId(userId)).ReturnsAsync(new List<DndCharacter>());

        var result = await _characterService.GetByUserIdAsync(userId);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetByUserIdAsync_UserHasCharacters_ReturnsCharacters()
    {
        var userId = 1;
        var characters = new List<DndCharacter>
        {
            new DndCharacter { CharacterId = 1, CharacterName = "Character 1", UserId = userId },
            new DndCharacter { CharacterId = 2, CharacterName = "Character 2", UserId = userId }
        };
        _mockCharacterRepo.Setup(repo => repo.GetByUserId(userId)).ReturnsAsync(characters);

        var result = await _characterService.GetByUserIdAsync(userId);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetAllAsync_CharactersExist_ReturnsAllCharacters()
    {
        var characters = new List<DndCharacter>
        {
            new DndCharacter { CharacterId = 1, CharacterName = "Character 1" },
            new DndCharacter { CharacterId = 2, CharacterName = "Character 2" }
        };
        _mockCharacterRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(characters);

        var result = await _characterService.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddAsync_ValidCharacter_AddsCharacterAndAssociatesSpells()
    {
        var characterDto = new DndCharacterDTO { CharacterId = 1, CharacterName = "New Character", SpellIds = new List<int> { 1, 2 } };
        var character = DndCharacterUtility.DTOToDndCharacter(characterDto);

        _mockCharacterRepo.Setup(repo => repo.AddAsync(It.IsAny<DndCharacter>())).Returns(Task.CompletedTask);
        _mockCharacterSpellRepo.Setup(repo => repo.AddAsync(It.IsAny<CharacterSpell>())).Returns(Task.CompletedTask);

        await _characterService.AddAsync(characterDto);

        _mockCharacterRepo.Verify(repo => repo.AddAsync(It.IsAny<DndCharacter>()), Times.Once);
        _mockCharacterSpellRepo.Verify(repo => repo.AddAsync(It.IsAny<CharacterSpell>()), Times.Exactly(2));
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
        _mockCharacterRepo.Verify(repo => repo.GetByIdAsync(characterId), Times.Once); // Ensure GetByIdAsync was called
    }

    [Fact]
    public async Task UpdateAsync_CharacterExists_UpdatesCharacter()
    {
        // Arrange
        var characterId = 1;
        var characterDto = new DndCharacterDTO { CharacterId = characterId, CharacterName = "Updated Character" };
        var existingCharacter = new DndCharacter { CharacterId = characterId, CharacterName = "Original Character" };
        
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterId)).ReturnsAsync(existingCharacter);

        // Act
        await _characterService.UpdateAsync(characterDto);

        // Assert
        _mockCharacterRepo.Verify(repo => repo.GetByIdAsync(characterId), Times.Once); // Ensure GetByIdAsync was called
        _mockCharacterRepo.Verify(repo => repo.UpdateAsync(It.Is<DndCharacter>(c => 
            c.CharacterId == characterId && c.CharacterName == characterDto.CharacterName)), Times.Once); // Ensure UpdateAsync was called
    }

    [Fact]
    public async Task UpdateAsync_CharacterDoesNotExist_ThrowsCharacterNotFoundException()
    {
        var characterDto = new DndCharacterDTO { CharacterId = 1, CharacterName = "Updated Character" };
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterDto.CharacterId)).ReturnsAsync((DndCharacter?)null);

        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterService.UpdateAsync(characterDto));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task DeleteAsync_CharacterDoesNotExist_ThrowsCharacterNotFoundException()
    {
        var characterId = 1;
        _mockCharacterRepo.Setup(repo => repo.GetByIdAsync(characterId)).ReturnsAsync((DndCharacter?)null);

        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _characterService.DeleteAsync(characterId));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetCharacterSpellsAsync_NoSpells_ReturnsEmptyList()
    {
        var characterId = 1;
        _mockCharacterSpellRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<CharacterSpell>());

        var result = await _characterService.GetCharacterSpellsAsync(characterId);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task AddSpellToCharacterAsync_SpellAlreadyExists_DoesNotAddSpell()
    {
        var characterId = 1;
        var spellId = 1;
        var existingCharacterSpell = new CharacterSpell { CharacterId = characterId, SpellId = spellId };

        _mockCharacterSpellRepo.Setup(repo => repo.GetByIdAsync(characterId, spellId)).ReturnsAsync(existingCharacterSpell);

        await _characterService.AddSpellToCharacterAsync(characterId, spellId);

        _mockCharacterSpellRepo.Verify(repo => repo.AddAsync(It.IsAny<CharacterSpell>()), Times.Never);
    }

    [Fact]
    public async Task AddSpellToCharacterAsync_ValidSpell_AddsSpellToCharacter()
    {
        var characterId = 1;
        var spellId = 1;

        _mockCharacterSpellRepo.Setup(repo => repo.GetByIdAsync(characterId, spellId)).ReturnsAsync((CharacterSpell?)null);
        _mockCharacterSpellRepo.Setup(repo => repo.AddAsync(It.IsAny<CharacterSpell>())).Returns(Task.CompletedTask);

        await _characterService.AddSpellToCharacterAsync(characterId, spellId);

        _mockCharacterSpellRepo.Verify(repo => repo.AddAsync(It.IsAny<CharacterSpell>()), Times.Once);
    }

    [Fact]
    public async Task RemoveSpellFromCharacterAsync_ValidSpell_RemovesSpellFromCharacter()
    {
        var characterId = 1;
        var spellId = 1;

        await _characterService.RemoveSpellFromCharacterAsync(characterId, spellId);

        _mockCharacterSpellRepo.Verify(repo => repo.DeleteAsync(characterId, spellId), Times.Once);
    }
}