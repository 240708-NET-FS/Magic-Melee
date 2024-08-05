using ApiUtil.DTO;
using ApiUtil.DTO.Classes;
using Newtonsoft.Json;  

namespace ApiUtil.Controller; 

class ClassController : IDungeonController {
     public static string GetBaseURL()  {
        return "https://www.dnd5eapi.co/api/classes/"; 
    } 

    private static readonly HttpClient s_client = new() 
    {
        BaseAddress = new Uri(GetBaseURL())
    }; 

      public static async Task<List<ClassDTO>> GetAllClasses() {
        using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL()) ; 
        var responseString = await response.Content.ReadAsStringAsync(); 
        // deserialize 
        ApiResponseDTO<GenericResourceDTO> apiResponseDTO = JsonConvert.DeserializeObject<ApiResponseDTO<GenericResourceDTO>>(responseString) ; 
        List<GenericResourceDTO> classShellDTOs = apiResponseDTO.Results; 
        List<ClassDTO> classes = []; 
        foreach(GenericResourceDTO classShellDTO in classShellDTOs) {
            classes.Add(await GetClassDTO(classShellDTO)); 
        }
        return classes; 
    }


     public static async  Task<ClassDTO> GetClassDTO(GenericResourceDTO classShellDTO) {
        string url = classShellDTO.Url; 
        using HttpResponseMessage response = await s_client.GetAsync(GetBaseURL() + url[13..]); 
        var responseString = await response.Content.ReadAsStringAsync(); 
        // deserialize 
        ClassDTO classDTO = JsonConvert.DeserializeObject<ClassDTO>(responseString); 
        return classDTO; 

    }



}