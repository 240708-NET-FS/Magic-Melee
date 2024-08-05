// Program.cs is here purely for ApiUtil testing 

using ApiUtil.Controller;
using ApiUtil.DTO.Races;
using ApiUtil.DTO.Spells;

namespace ApiUtil; 

public class ApiUtil {
    public static void Main(string[] args ) {
        //List<SpellEntityDTO> spells = SpellController.GetAllSpells().GetAwaiter().GetResult(); 
        string className = "paladin"; 
        List<SpellEntityDTO> spells = SpellController.GetSpellsByClass(className).GetAwaiter().GetResult(); 
        System.Console.WriteLine($"Found {spells.Count} spells for class {className}: ");
        for(int i = 0; i< spells.Count; i++ ) System.Console.WriteLine(spells[i].Name);

        //List<RaceDTO> races = RaceController.GetAllRaces().GetAwaiter().GetResult(); 
        //for(int i = 0; i < races.Count; i++) System.Console.WriteLine($"Name: {races[i].name} | Speed: {races[i].speed}");
    }
}