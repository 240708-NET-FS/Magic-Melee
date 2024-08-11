// expects an object of skills tied to characterID
import axios from "axios";
import server from "./server";
const endpoint = "api/Skills/character/";
const getSkills = async (charID) => {
  const response = await axios.get(server + endpoint + charID);
  return response.data;
};

export default getSkills;
