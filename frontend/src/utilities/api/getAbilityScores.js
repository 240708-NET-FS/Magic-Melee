// expects a list of characters tied to user to display
import axios from "axios";
import server from "./server";
const endpoint = "api/AbilityScoreArr/character/";
const getAbilityScores = async (charID) => {
  const response = await axios.get(server + endpoint + charID);
  return response.data;
};

export default getAbilityScores;
