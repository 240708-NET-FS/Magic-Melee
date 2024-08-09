namespace MagicMelee.ApiUtil.DTO.Monsters; 
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
        string damageVulnerabilities = DamageVulnerabilities.Count > 0 ? DamageVulnerabilities[0] : "N/A"; 
        return $"Name : {Name} | Armor Class: {ArmorClass[0].Value } | Damage Vulnerabilities: {damageVulnerabilities}";
        //return $"Name : {Name} | Damage Vulnerabilities: {damageVulnerabilities}";
        //return $"Name : {Name} | HP: {HitPoints}";
    }

    public static MonsterDTO Search(string name , List<MonsterDTO> monsters) {
        // monsters are alphabetically sorted when they come in 
        int left = 0; 
        int right = monsters.Count-1; 
        int mid  = right/2; 
        while ( left < right) {
            if (monsters[mid].Name == name  ) return monsters[mid]; 
            else if (monsters[mid].Name[0] > name[0] ) right= mid-1; 
            else left = mid+1; 
            mid = (left + right ) / 2; 
        }
        if(monsters[mid].Name == name ) return monsters[mid];
        return null;   
    }

}

public class ArmorClassDTO(string type, string value){
    public string Type = type; 
    public string Value = value; 

}