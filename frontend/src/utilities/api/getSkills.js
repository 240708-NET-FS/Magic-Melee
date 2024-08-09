// expects an object of skills tied to characterID
import axios from "axios";
const server = "http://localhost:3000/";
const endpoint = "api/skills?characterid=";
const getSkills = async (charID) => {
  const response = await axios.get(server + endpoint + charID);
  return response.data;
};

export default getSkills;
