
namespace MagicMelee.ApiUtil.DTO.Classes; 

public class ClassDTO(string index , string name, int hit_die, List<GenericResourceDTO> subclasses, List<GenericResourceDTO> starting_equipment ) 
{
    public string ID=index; 
    public int HitDie = hit_die; 

    public string Name = name ; 

   public List<GenericResourceDTO> Subclasses = subclasses; 

   public List<GenericResourceDTO> StartingEquipment = starting_equipment;

    public override string ToString()
    {

        string subclassNames= "" ; 
        foreach ( GenericResourceDTO subclass in Subclasses) subclassNames += subclass.Name + ","; 
        subclassNames = subclassNames.Substring(0,subclassNames.Length- 1);
        return $"Name: {Name} | Hit Die: {HitDie} | Subclasses: {subclassNames} ";
    }

}