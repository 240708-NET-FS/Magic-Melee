namespace MagicMelee.Models;

public class CharacterClass
{
    public int CharacterClassId { get; set; }
    public string Name { get; set; } = string.Empty;

    public DndCharacter DndCharacter { get; set; }
}