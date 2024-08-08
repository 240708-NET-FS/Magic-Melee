namespace Magic_Melee.ApiUtil.DTO.Items; 
public class EquipmentOptionsListDTO(string desc, int choose, FromEquipmentOptionsDTO from) {
    public string Description = desc; 
    public int choose = choose ;

    public FromEquipmentOptionsDTO FromList = from ; 
}

public class FromEquipmentOptionsDTO(List<EquipmentOptionDTO> options) {
    public List<EquipmentOptionDTO> Options = options; 
}

public class EquipmentOptionDTO(int count, GenericResourceDTO of) {
    public int Count = count ; 
    public GenericResourceDTO Choice= of; 
}