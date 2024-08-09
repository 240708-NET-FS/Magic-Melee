// return character DTO for a character with specific ID
import axios from "axios";
import server from "./server";
const endpoint = "api/DndCharacter/";
const getCharacter = async (charID) => {
  const response = await axios.get(server + endpoint + charID);
  return response.data;
};
export default getCharacter;
