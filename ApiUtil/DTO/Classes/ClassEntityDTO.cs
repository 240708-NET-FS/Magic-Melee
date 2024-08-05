namespace ApiUtil.DTO.Classes; 
public class ClassEntityDTO(string index , string name, int hit_die, List<ClassShellDTO> subclasses ) 
{
    string ID=index; 
    int HitDie = hit_die; 

    string Name = name ; 

    List<ClassShellDTO> Subclasses = subclasses; 

}