using ApiUtil.DTO;
using ApiUtil.DTO.Spells;
using Newtonsoft.Json;  
namespace ApiUtil.Controller; 


class SpellController : IDungeonController {
    public static string GetBaseURL()  {
        return "https://www.dnd5eapi.co/api/spells/"; 
    } 


    private static readonly HttpClient s_client = new() 
    {
        BaseAddress = new Uri(GetBaseURL())
    }; 
    public static async Task<List<SpellEntityDTO?>> GetAllSpells() 
    {
 

        List<SpellEntityDTO?> spells = []; 
        try 
        {
            List<SpellInboundDTO> spellInboundDTOs = await GetAllSpellInboundDTOs(); 

            foreach ( SpellInboundDTO spellInboundDTO in spellInboundDTOs ){
                //System.Console.WriteLine($"adding spell : {spellShells[i].name}");
                SpellEntityDTO spell = GetSpellEntityDTO(spellInboundDTO); 
                if(spell!= null) spells.Add(spell);  
            }

            return spells; 

        } catch (Exception e)
        {
            System.Console.WriteLine($"Error in GetAllSpells: {e.Message}");
            return spells ;
        }
    }

    public async static Task<List<SpellInboundDTO>> GetAllSpellInboundDTOs() 
    {
        using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL());
        List<SpellShellInboundDTO> spellShells = [] ; 
        var streamResponse = await response.Content.ReadAsStringAsync();
        ApiResponseDTO<SpellShellInboundDTO> responseDTO = JsonConvert.DeserializeObject<ApiResponseDTO<SpellShellInboundDTO>>(streamResponse); 
        spellShells = responseDTO.results; 

        List<SpellInboundDTO> spellInboundDTOs = [] ; 
        foreach(SpellShellInboundDTO spellShell in spellShells) {
            spellInboundDTOs.Add(await GetSpellInboundDTO(spellShell));
        }

        return spellInboundDTOs; 
    }

    public static async Task<SpellInboundDTO?> GetSpellInboundDTO(SpellShellInboundDTO spellShell) 
    {
        string spellURL = GetBaseURL() + spellShell.url[12..]; 
        using HttpResponseMessage response = await s_client.GetAsync(spellURL); 
        

        try 
        {
            response.EnsureSuccessStatusCode(); 
            var streamResponse = await response.Content.ReadAsStringAsync(); 
            SpellInboundDTO? spell = JsonConvert.DeserializeObject<SpellInboundDTO>(streamResponse); 
            return spell; 
        } catch(Exception e) 
        {
            System.Console.WriteLine($"Error in GetSpellInboundDTO: {e.Message}");
            return null ;
        }
     }

     public static SpellEntityDTO GetSpellEntityDTO(SpellInboundDTO spellInboundDTO) 
     {
        string damageType= "N/A"; 
        if(spellInboundDTO.damage != null && spellInboundDTO.damage.damage_type !=null) damageType = spellInboundDTO.damage.damage_type.name; 

        return new SpellEntityDTO(spellInboundDTO.name, spellInboundDTO.range, spellInboundDTO.level, damageType);
     }

    public static async Task<List<SpellEntityDTO>> GetSpellsByClass(string className) {
        // in lieu of the ability to properly query the graphQL endpoint (which would surely make this easier )
        // we get list of all spells then filter by those who return true for CanUseSpell(className)

        List<SpellInboundDTO> spellInboundDTOs = await GetAllSpellInboundDTOs(); 
        List<SpellEntityDTO> validSpells = []; 
        foreach(SpellInboundDTO spellInboundDTO in spellInboundDTOs) {
            if( ClassCanUseSpell(className, spellInboundDTO)) 
            {
                validSpells.Add(GetSpellEntityDTO(spellInboundDTO)); 
            }
        }

        return validSpells; 
    }

    public static bool ClassCanUseSpell(string className, SpellInboundDTO spell) {
        foreach ( SpellClassesDTO spellClassesDTO in spell.classes) {
            if(className.Equals(spellClassesDTO.name,StringComparison.CurrentCultureIgnoreCase)) return true; 
        }
        return false; 
    }

}