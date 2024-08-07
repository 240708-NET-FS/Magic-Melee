namespace MagicMelee.DTO;
public class SpellDTO
{
    public int SpellId { get; set; }
    public string SpellName { get; set; } = string.Empty;
    public int SpellRange { get; set; }
    public int SpellLevel { get; set; }
    public string SpellDamageType { get; set; } = string.Empty;
}