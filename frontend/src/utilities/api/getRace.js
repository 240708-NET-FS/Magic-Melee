import axios from "axios";
import server from "./server";
const endpoint = "api/races?id=";
const getRace = async (CharacterRaceID) => {
  const response = await axios.get(server + endpoint + CharacterRaceID);
  return response.data;
};
export default getRace;
