namespace ApiUtil.DTO.Monsters; 
public class MonsterDTO(string index, string name, string hit_dice, List<ArmorClassDTO> armor_class, int hit_points, int strength, int dexterity, int constitution, int wisdom, int charisma, int intelligence, List<string> damage_vulnerabilities, List<string> damage_resistances, List<string> damage_immunities)
{

    public string ID = index; 
    public string Name = name ;
    public string HitDice = hit_dice; 

    public List<ArmorClassDTO> ArmorClass = armor_class; 

    public int HitPoints = hit_points; 

    public int strength = strength; 
    public int dexterity = dexterity; 
    public int constitution = constitution; 
    public int wisdom = wisdom; 
    public int intelligence = intelligence; 
    public int charisma =charisma; 

    public List<string> DamageVulnerabilities = damage_vulnerabilities; 
    public List<string> DamageImmunities = damage_immunities; 
    public List<string> DamageResistances = damage_resistances;

    public override string ToString()
    {
        string damageVulnerabilities = DamageVulnerabilities.Count > 0? DamageVulnerabilities[0] : "N/A"; 
        return $"Name : {Name} | Damage Vulnerabilities: {damageVulnerabilities}";
    }
}

public class ArmorClassDTO(string type, string value){
    public string Type = type; 
    public string Value = value; 

}