using MagicMelee.DTO;
using MagicMelee.Models;

namespace MagicMelee.Utilities;

public static class UserUtility
{
public static User DTOToUser(UserDTO userDTO)
    {
        return new User
        {
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName
        };
    }

    public static UserDTO UserToDTO(User user)
    {
        return new UserDTO
        {
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}

public static class DndCharacterUtility
{
    public static DndCharacter DTOToDndCharacter(DndCharacterDTO characterDTO)
    {
        return new DndCharacter
        {
            CharacterName = characterDTO.CharacterName,
            CharacterRaceId = characterDTO.CharacterRaceId,
            CharacterClassId = characterDTO.CharacterClassId,
            AbilityScoreArrId = characterDTO.AbilityScoreArrId,
            SkillsId = characterDTO.SkillsId,
            HitPoints = characterDTO.HitPoints,
            UserId = characterDTO.UserId
        };
    }

    public static DndCharacterDTO DndCharacterToDTO(DndCharacter character)
    {
        return new DndCharacterDTO
        {
            CharacterName = character.CharacterName,
            CharacterRaceId = character.CharacterRaceId,
            CharacterClassId = character.CharacterClassId,
            AbilityScoreArrId = character.AbilityScoreArrId,
            SkillsId = character.SkillsId,
            HitPoints = character.HitPoints,
            UserId = character.UserId
        };
    }
}

public static class CharacterClassUtility
{
    public static CharacterClass DTOToCharacterClass(CharacterClassDTO dto)
    {
        return new CharacterClass
        {
            CharacterClassId = dto.CharacterClassId,
            Name = dto.Name
        };
    }

    public static CharacterClassDTO CharacterClassToDTO(CharacterClass characterClass)
    {
        return new CharacterClassDTO
        {
            CharacterClassId = characterClass.CharacterClassId,
            Name = characterClass.Name
        };
    }
}

public static class SpellUtility
{
    public static SpellDTO SpellToDTO(Spell spell)
    {
        return new SpellDTO
        {
            SpellId = spell.SpellId,
            SpellName = spell.SpellName,
            SpellRange = spell.SpellRange,
            SpellLevel = spell.SpellLevel,
            SpellDamageType = spell.SpellDamageType
        };
    }

    public static Spell DTOToSpell(SpellDTO spellDto)
    {
        return new Spell
        {
            SpellId = spellDto.SpellId,
            SpellName = spellDto.SpellName,
            SpellRange = spellDto.SpellRange,
            SpellLevel = spellDto.SpellLevel,
            SpellDamageType = spellDto.SpellDamageType
        };
    }
}

public static class AbilityScoreArrUtility
{
    public static AbilityScoreArrDTO AbilityScoreArrToDTO(AbilityScoreArr abilityScoreArr)
    {
        return new AbilityScoreArrDTO
        {
            AbilityScoreArrId = abilityScoreArr.AbilityScoreArrId,
            Str = abilityScoreArr.Str,
            Dex = abilityScoreArr.Dex,
            Con = abilityScoreArr.Con,
            Int = abilityScoreArr.Int,
            Wis = abilityScoreArr.Wis,
            Cha = abilityScoreArr.Cha
        };
    }

    public static AbilityScoreArr DTOToAbilityScoreArr(AbilityScoreArrDTO abilityScoreArrDto)
    {
        return new AbilityScoreArr
        {
            AbilityScoreArrId = abilityScoreArrDto.AbilityScoreArrId,
            Str = abilityScoreArrDto.Str,
            Dex = abilityScoreArrDto.Dex,
            Con = abilityScoreArrDto.Con,
            Int = abilityScoreArrDto.Int,
            Wis = abilityScoreArrDto.Wis,
            Cha = abilityScoreArrDto.Cha
        };
    }
}