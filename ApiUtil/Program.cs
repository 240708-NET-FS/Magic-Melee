// Program.cs is here purely for ApiUtil testing 

using ApiUtil.Controller;
using ApiUtil.DTO.Races;
using ApiUtil.DTO.Spells;
using ApiUtil.DTO.Classes;
using ApiUtil.DTO.Monsters;

namespace ApiUtil; 

public class ApiUtil {
    public static void Main(string[] args ) {
        //List<SpellEntityDTO> spells = SpellController.GetAllSpells().GetAwaiter().GetResult(); 
        // string className = "paladin"; 
        // List<SpellEntityDTO> spells = SpellController.GetSpellsByClass(className).GetAwaiter().GetResult(); 
        // System.Console.WriteLine($"Found {spells.Count} spells for class {className}: ");
        // for(int i = 0; i< spells.Count; i++ ) System.Console.WriteLine(spells[i].Name);

        // List<RaceDTO> races = RaceController.GetAllRaces().GetAwaiter().GetResult(); 
        // for(int i = 0; i < races.Count; i++) System.Console.WriteLine($"Name: {races[i].Name} | Speed: {races[i].Speed}");


        // List<ClassDTO> classes = ClassController.GetAllClasses().GetAwaiter().GetResult(); 
        // for(int i = 0; i < classes.Count; i++) System.Console.WriteLine(classes[i]);

        //List<MonsterDTO> monsters= MonsterController.GetAllMonsters().GetAwaiter().GetResult(); 
        //for(int i = 0; i < monsters.Count; i++) System.Console.WriteLine(monsters[i]);
        System.Console.WriteLine( MonsterController.FindMonster("Half-Red Dragon Veteran").GetAwaiter().GetResult());
        System.Console.WriteLine( MonsterController.FindMonster("Awakened Shrub").GetAwaiter().GetResult());
        //System.Console.WriteLine( MonsterController.FindMonster("Xorn").GetAwaiter().GetResult());

    }
}