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
        using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL());
        List<SpellShellInboundDTO?> spellShells = [] ; 

        List<SpellEntityDTO?> spells = []; 
        try 
        {
            response.EnsureSuccessStatusCode();
            var streamResponse = await response.Content.ReadAsStringAsync();
            ApiResponseDTO<SpellShellInboundDTO> responseDTO = JsonConvert.DeserializeObject<ApiResponseDTO<SpellShellInboundDTO>>(streamResponse); 
            spellShells = responseDTO.results; 

            for ( int i = 0; i < spellShells.Count; i++ ){
                System.Console.WriteLine($"adding spell : {spellShells[i].name}");
                SpellInboundDTO spellInboundDTO = await GetSpellInboundDTO(spellShells[i]);
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
        if(spellInboundDTO.damage != null) damageType = spellInboundDTO.damage.damage_type.name; 

        return new SpellEntityDTO(spellInboundDTO.name, spellInboundDTO.range, spellInboundDTO.level, damageType);
     }



}