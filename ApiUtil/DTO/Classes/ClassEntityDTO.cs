
namespace ApiUtil.DTO.Classes; 

public class ClassEntityDTO(string index , string name, int hit_die, List<GenericResourceDTO> subclasses, List<GenericResourceDTO> starting_equipment_options ) 
{
    public string ID=index; 
    public int HitDie = hit_die; 

    public string Name = name ; 

   public List<GenericResourceDTO> Subclasses = subclasses; 

   public List<GenericResourceDTO> StartingEquipmentOptions = starting_equipment_options; 

}