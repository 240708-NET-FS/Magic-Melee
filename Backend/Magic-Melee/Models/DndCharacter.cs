using System.ComponentModel.DataAnnotations;

namespace MagicMelee.Models;

public class DndCharacter
{
    [Key]
    public int CharacterId { get; set; }
    public string CharacterName { get; set; } = string.Empty;
    public int HitPoints { get; set; }
    public int MaxHitPoints { get; set; }
    public int CharacterLevel { get; set; }
    
    // Foreign key for users
    public int UserId { get; set; } 
    public User User { get; set; }

    //  Foreign key for CharacterRace
    public int CharacterRaceId { get; set; }
    public CharacterRace CharacterRace { get; set; }

    // Foreign key for CharacterClass
    public int CharacterClassId { get; set; }
    public CharacterClass CharacterClass { get; set; }

    // Foreign key for AbilityScoreArrId
    public int AbilityScoreArrId { get; set; }
    public AbilityScoreArr AbilityScoreArr { get; set; }

    // Foreign key for Skills
    public int SkillsId { get; set; }
    public Skills Skills { get; set; }

    // Many to many relationship with spell
    public List<CharacterSpell> CharacterSpells { get; set; } = new List<CharacterSpell>(); 

}