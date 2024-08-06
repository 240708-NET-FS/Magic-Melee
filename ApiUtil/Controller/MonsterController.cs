using ApiUtil.DTO.Monsters;
using ApiUtil.DTO; 
using Newtonsoft.Json;

namespace ApiUtil.Controller; 
public class MonsterController : IDungeonController {
    public static readonly string endpoint="/api/monsters/";
    public static string GetBaseURL()  
    {
        return $"https://www.dnd5eapi.co{endpoint}"; 
    } 

    private static readonly HttpClient s_client = new() 
    {
        BaseAddress = new Uri(GetBaseURL())
    }; 
    public static async Task<List<MonsterDTO>> GetAllMonsters() {
         using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL()) ; 
        var responseString = await response.Content.ReadAsStringAsync(); 
        // deserialize 
        ApiResponseDTO<GenericResourceDTO> apiResponseDTO = JsonConvert.DeserializeObject<ApiResponseDTO<GenericResourceDTO>>(responseString) ; 
        List<GenericResourceDTO> classShellDTOs = apiResponseDTO.Results; 
        List<MonsterDTO> monsters = []; 
        foreach(GenericResourceDTO classShellDTO in classShellDTOs) {
            monsters.Add(await GetMonsterDTO(classShellDTO)); 
        }
        return monsters; 
    }

    public static async  Task<MonsterDTO?> GetMonsterDTO(GenericResourceDTO classShellDTO) {
        string url = classShellDTO.Url; 
        using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL() + url[13..]); 
        var responseString = await response.Content.ReadAsStringAsync(); 
        // deserialize 
        MonsterDTO?  monsterDTO = JsonConvert.DeserializeObject<MonsterDTO>(responseString); 
        return monsterDTO; 

    }

    public static async Task<MonsterDTO?> FindMonster(string name) {
        string index=GenericResourceDTO.NameToIndex(name); 
        GenericResourceDTO genericResourceDTO=  new(index, name, endpoint + index); 
        MonsterDTO monsterDTO = await GetMonsterDTO(genericResourceDTO); 
        return monsterDTO; 
    }
}