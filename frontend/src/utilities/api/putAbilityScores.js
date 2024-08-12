// expects a list of characters tied to user to display
import axios from "axios";
import server from "./server";
const endpoint = "api/AbilityScoreArr/";
const putAbilityScores = async (abilityScoreArrId, abilityScores) => {
  const response = await axios.put(server + endpoint + abilityScoreArrId, {
    abilityScoreArrId: abilityScoreArrId,
    ...abilityScores,
  });
  return response.data;
};

export default putAbilityScores;
