// Program.cs is here purely for ApiUtil testing 

using ApiUtil.Controller;
using ApiUtil.DTO.Spells;

namespace ApiUtil; 

public class ApiUtil {
    public static void Main(string[] args ) {
        List<SpellEntityDTO> spells = SpellController.GetAllSpells().GetAwaiter().GetResult(); 
        for(int i = 0; i< spells.Count; i++ ) System.Console.WriteLine(spells[i].ToString());
    }
}