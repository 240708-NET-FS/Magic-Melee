using Magic_Melee.ApiUtil.DTO;
using Magic_Melee.ApiUtil.DTO.Races;
using Newtonsoft.Json;  
namespace Magic_Melee.ApiUtil.Controller; 

public class RaceController : IDungeonController {

    public static string GetBaseURL()  {
        return "https://www.dnd5eapi.co/api/races/"; 
    } 

    private static readonly HttpClient s_client = new() 
    {
        BaseAddress = new Uri(GetBaseURL())
    }; 


    public static async Task<List<RaceDTO>> GetAllRaces() {
        using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL()) ; 
        var responseString = await response.Content.ReadAsStringAsync(); 
        // deserialize 
        ApiResponseDTO<RaceShellDTO> apiResponseDTO = JsonConvert.DeserializeObject<ApiResponseDTO<RaceShellDTO>>(responseString) ; 
        List<RaceShellDTO> raceShellDTOs = apiResponseDTO.Results; 
        List<RaceDTO> races = []; 
        foreach(RaceShellDTO raceShellDTO in raceShellDTOs) {
            races.Add(await GetRaceDTO(raceShellDTO)); 
        }
        return races; 
    }

    public static async  Task<RaceDTO> GetRaceDTO(RaceShellDTO raceShellDTO) {
        string url = raceShellDTO.Url; 
        using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL() + url[11..]); 
        var responseString = await response.Content.ReadAsStringAsync(); 
        // deserialize 
        RaceDTO raceDTO = JsonConvert.DeserializeObject<RaceDTO>(responseString); 
        return raceDTO; 

    }

    // }
}