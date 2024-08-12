// expects a list of characters tied to user to display
import axios from "axios";
import server from "./server";
const endpoint = "api/skills/";
const putSkills = async (skills) => {
  try{
    const response = await axios.put(server + endpoint + skills.skillsId, {
      ...skills,
    });
    return response.data;

  }catch(error){
    console.error(error);
  }
  
};

export default putSkills;
