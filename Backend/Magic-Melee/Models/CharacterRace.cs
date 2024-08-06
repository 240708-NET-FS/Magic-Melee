namespace MagicMelee.Models;

public class CharacterRace
{
    public int CharacterRaceId { get; set; }
    public string Name { get; set; } = string.Empty;

    public int Speed { get; set; }

    public DndCharacter DndCharacter { get; set; }
}