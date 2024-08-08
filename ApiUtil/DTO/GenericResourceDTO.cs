namespace ApiUtil.DTO; 
// generic resource DTO 
public class GenericResourceDTO (string index, string name, string url) {
    public string ID=index; 
    public string Name = name ; 

    public string Url = url ; 

    public static string NameToIndex(string name ) {
        //convert string to lowercase 
        string result = name.ToLower(); 
        return result.Replace(' ','-');
    }
}