namespace Magic_Melee.ApiUtil.DTO.Spells; 
public class SpellEntityDTO( string name , string range, int level, string DamageType) {

 
    public string Name = name; 
    public string Range = range; 
    public int Level = level; 

    public string? DamageType = DamageType ?? "N/A" ;

    public override string ToString()
    {
        return $"Name: {name} \nRange: {Range} \nLevel: {Level} \nDamage Type: {DamageType}"; 
    }
}