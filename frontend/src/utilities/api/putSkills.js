// expects a list of characters tied to user to display
import axios from "axios";
const server = "http://localhost:3000/";
const endpoint = "api/skills?charid=";
const putSkills = async (charID, skills) => {
  const response = await axios.put(server + endpoint + charID, skills);
  return response.data;
};

export default putSkills;
