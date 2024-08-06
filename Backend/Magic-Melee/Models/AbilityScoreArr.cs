namespace MagicMelee.Models;

public class AbilityScoreArr
{
    public int AbilityScoreArrId { get; set; }
    public int Str { get; set; }
    public int Dex { get; set; }
    public int Con { get; set; }
    public int Int { get; set; }
    public int Wis { get; set; }
    public int Cha { get; set; }

    // Navigation property for the one-to-one relationship with DndCharacter
    public DndCharacter DndCharacter { get; set; }
}