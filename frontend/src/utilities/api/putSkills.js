// expects a list of characters tied to user to display
import axios from "axios";
import server from "./server";
const endpoint = "api/skills/character/";
const putSkills = async (skills) => {
  const response = await axios.put(server + endpoint + skills.skillsId, {
    ...skills,
  });
  return response.data;
};

export default putSkills;
