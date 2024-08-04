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
    public static async Task<List<SpellShellInboundDTO>> GetAllSpells() {
        using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL());
        List<SpellShellInboundDTO>? spells = [] ; 
        try 
        {
            response.EnsureSuccessStatusCode();
            var streamResponse = await response.Content.ReadAsStringAsync();
            SpellsInboundResponseDTO responseDTO = JsonConvert.DeserializeObject<SpellsInboundResponseDTO>(streamResponse); 
            spells = responseDTO.results; 


            return spells; 

        } catch (Exception e)
        {
            System.Console.WriteLine($"Error in spell Controller: {e.Message}");
            return spells ;
        }
    }


}