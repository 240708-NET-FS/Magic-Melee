import axios from "axios";
import server from "./server";
const endpoint = "api/classes?id=";
const getClass = async (CharacterClassID) => {
  const response = await axios.get(server + endpoint + CharacterClassID);
  return response.data;
};
export default getClass;
