namespace MagicMelee.Models;

public class DndCharacter
{
    public int CharacterId { get; set; }
    public string CharacterName { get; set; } = string.Empty;
    public int CharacterRaceId { get; set; }
    public int HitPoints { get; set; }
    public int MaxHitPoints { get; set; }
    public int CharacterLevel { get; set; }
    
    public int UserId { get; set; } // Foreign key
    public User User { get; set; }

    public List<CharacterSpell> CharacterSpells { get; set; } = new List<CharacterSpell>(); 

}