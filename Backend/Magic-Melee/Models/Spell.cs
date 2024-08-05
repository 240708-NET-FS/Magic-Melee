namespace MagicMelee.Models;

public class Spell
{
    public int SpellId { get; set; }
    public string SpellName { get; set; } = string.Empty;
    public string SpellRange { get; set; } = string.Empty;
    public int SpellLevel { get; set; }
    public string SpellDamageType { get; set; } = string.Empty;

    public List<CharacterSpell> CharacterSpells { get; set; } = new List<CharacterSpell>();
}