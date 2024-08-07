namespace MagicMelee.DTO;

public class DndCharacterDTO
{
    public int CharacterId { get; set; }
    public string CharacterName { get; set; } = string.Empty;
    public int HitPoints { get; set; }

    public int UserId { get; set; }
    public int CharacterRaceId { get; set; }
    public int CharacterClassId { get; set; }
    public int AbilityScoreArrId { get; set; }
    public int SkillsId { get; set; }
    
    public List<int> SpellIds { get; set; } = new List<int>();
}