namespace Magic_Melee.ApiUtil.DTO.Races; 

public class RaceDTO (string name, string url, int speed, List<AbilityBonusDTO> ability_bonuses) {
    public string Name = name ; 

    public string Url = url; 

    public int Speed = speed; 

    public List<AbilityBonusDTO> ability_bonuses = ability_bonuses; 
}