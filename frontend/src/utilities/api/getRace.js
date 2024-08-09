// get character race by ID
import axios from "axios";
import server from "./server";
const endpoint = "api/CharacterRace/";
const getRace = async (CharacterRaceID) => {
  const response = await axios.get(server + endpoint + CharacterRaceID);
  return response.data;
};
export default getRace;
