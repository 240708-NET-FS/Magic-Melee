// return list of existing character races
import axios from "axios";
import server from "./server";
const endpoint = "api/CharacterRace";
const getAllRaces = async () => {
  const response = await axios.get(server + endpoint);
  return response.data;
};
export default getAllRaces;
