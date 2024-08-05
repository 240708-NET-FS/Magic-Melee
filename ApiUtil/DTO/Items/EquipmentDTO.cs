namespace ApiUtil.DTO.Items; 
public class EquipmentDTO (string index, string name , string? armor_category, ArmorClassDTO armor_class, int weight) {
    public string ID = index ; 
    public string Name = name ;

    public string? ArmorCategory = armor_category; 

    public ArmorClassDTO? ArmorClassDTO = armor_class; 

    public int Weight = weight; 
}

public class ArmorClassDTO ( int _base ,  bool dex_bonus) {
    public int Base = _base; 
    public bool DexBonus = dex_bonus; 
}