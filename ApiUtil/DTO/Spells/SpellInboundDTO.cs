namespace ApiUtil.DTO.Spells; 

class SpellInboundDTO (string name, int level , string url, string range, SpellDamageDTO damage, List<SpellClassesDTO> classes) {

    public string name = name ; 
    public int  level = level ; 

    public string url = url; 


    public List<SpellClassesDTO>  classes = classes; 
    
    public string range = range; 

    // the actual spell damaage type is damage.damage_type 
    public SpellDamageDTO? damage = damage; 

    
}