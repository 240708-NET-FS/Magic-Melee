using MagicMelee.DTO;
using MagicMelee.Models;
using MagicMelee.Utilities;
using Xunit;

namespace MagicMelee.Tests;

public class UtilitiesTests
{
    [Fact]
    public void DndCharacterToDTO_ShouldHandleNullCharacterSpells()
    {
        var character = new DndCharacter
        {
            CharacterId = 1,
            CharacterName = "Hero",
            CharacterSpells = null // Test case with null CharacterSpells
        };

        var dto = DndCharacterUtility.DndCharacterToDTO(character);

        Assert.NotNull(dto.SpellIds);  // The result should not be null
        Assert.Empty(dto.SpellIds);    // It should be an empty list
    }

    [Fact]
    public void DndCharacterToDTO_ShouldHandleEmptyCharacterSpells()
    {
        var character = new DndCharacter
        {
            CharacterId = 1,
            CharacterName = "Hero",
            CharacterSpells = new List<CharacterSpell>() // Test case with empty CharacterSpells
        };

        var dto = DndCharacterUtility.DndCharacterToDTO(character);

        Assert.NotNull(dto.SpellIds);
        Assert.Empty(dto.SpellIds);  // Should result in an empty list
    }

    [Fact]
    public void DndCharacterToDTO_ShouldHandlePopulatedCharacterSpells()
    {
        var character = new DndCharacter
        {
            CharacterId = 1,
            CharacterName = "Hero",
            CharacterSpells = new List<CharacterSpell>
            {
                new CharacterSpell { SpellId = 1, CharacterId = 1 },
                new CharacterSpell { SpellId = 2, CharacterId = 1 }
            }
        };

        var dto = DndCharacterUtility.DndCharacterToDTO(character);

        Assert.Equal(2, dto.SpellIds.Count);
        Assert.Contains(1, dto.SpellIds);
        Assert.Contains(2, dto.SpellIds);
    }

    [Fact]
    public void DTOToDndCharacter_ShouldHandleEmptySpellIds()
    {
        var characterDTO = new DndCharacterDTO
        {
            CharacterId = 1,
            CharacterName = "Hero",
            SpellIds = new List<int>()  // Test case with empty SpellIds
        };

        var character = DndCharacterUtility.DTOToDndCharacter(characterDTO);

        Assert.NotNull(character.CharacterSpells);
        Assert.Empty(character.CharacterSpells);
    }

    [Fact]
    public void DTOToDndCharacter_ShouldMapSpellIdsCorrectly()
    {
        var characterDTO = new DndCharacterDTO
        {
            CharacterId = 1,
            CharacterName = "Hero",
            SpellIds = new List<int> { 1, 2 }
        };

        var character = DndCharacterUtility.DTOToDndCharacter(characterDTO);

        Assert.Equal(2, character.CharacterSpells.Count);
        Assert.Contains(character.CharacterSpells, cs => cs.SpellId == 1);
        Assert.Contains(character.CharacterSpells, cs => cs.SpellId == 2);
    }
}