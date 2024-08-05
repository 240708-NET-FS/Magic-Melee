namespace ApiUtil.DTO.Races; 

public class RaceDTO (string name, string url, int speed, List<AbilityBonusDTO> ability_bonuses) {
    public string name = name ; 

    public string url = url; 

    public int speed = speed; 

    public List<AbilityBonusDTO> ability_bonuses = ability_bonuses; 
}