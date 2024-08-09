using System.ComponentModel.DataAnnotations;

namespace MagicMelee.Models;

public class CharacterRace
{
    [Key]
    public int CharacterRaceId { get; set; }
    public string Name { get; set; } = string.Empty;

    public int Speed { get; set; }

    public DndCharacter DndCharacter { get; set; }
}