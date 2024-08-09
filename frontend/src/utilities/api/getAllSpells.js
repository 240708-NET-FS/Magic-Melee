// get all spells that a specific class can use
import axios from "axios";
import server from "./server";
const endpoint = "api/Spell/classid=";
const getAllSpells = async (CharacterClassName) => {
  const response = await axios.get(server + endpoint + CharacterClassName);
  return response.data;
};
export default getAllSpells;
// TODO: #9  if there's time , may pass this request straight to API without passing through our backend first.
