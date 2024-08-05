namespace MagicMelee.Models;

public class CharacterSpell
{
    public int CharacterId { get; set; }
    public DndCharacter DndCharacter { get; set; }

    public int SpellId { get; set; }
    public Spell Spell { get; set; }
}