// expects a list of characters tied to user to display
import axios from "axios";
import server from "./server";
const endpoint = "api/skills/";
const postSkills = async (skills) => {
  const response = await axios.post(server + endpoint, skills);
  return response.data;
};

export default postSkills;
