// expects a list of characters tied to user to display
import axios from "axios";
const server = "http://localhost:3000/";
const endpoint = "api/abilityscores?charid=";
const putAbilityScores = async (charID, abilityScores) => {
  const response = await axios.put(server + endpoint + charID, abilityScores);
  return response.data;
};

export default putAbilityScores;
