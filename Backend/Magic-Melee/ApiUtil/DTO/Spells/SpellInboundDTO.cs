namespace Magic_Melee.ApiUtil.DTO.Spells; 

class SpellInboundDTO (string name, int level , string url, string range, SpellDamageDTO damage, List<SpellClassesDTO> classes) {

    public string Name = name ; 
    public int  Level = level ; 

    public string Url = url; 


    public List<SpellClassesDTO>  SpellClassesDTOs = classes; 
    
    public string SpellRange = range; 

    // the actual spell damaage type is damage.damage_type 
    public SpellDamageDTO? DamageDTO = damage; 

    
}