using ApiUtil.DTO;
using ApiUtil.DTO.Spells;
using Newtonsoft.Json;  
namespace ApiUtil.Controller; 

public class RaceController : IDungeonController {

    public static string GetBaseURL()  {
        return "https://www.dnd5eapi.co/api/races/"; 
    } 

    private static readonly HttpClient s_client = new() 
    {
        BaseAddress = new Uri(GetBaseURL())
    }; 


    // public static Task<List<ApiResponseDTO<RaceDTO>>(){

    // }
}