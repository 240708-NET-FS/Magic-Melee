// get all spells that a specific class can use
import axios from "axios";
import server from "./server";
const endpoint = "api/DndCharacter/spells/";
const getCharacterSpells = async (CharacterID) => {
  const response = await axios.get(server + endpoint + CharacterID);
  return response.data;
};
export default getCharacterSpells;
// TODO: #9  if there's time , may pass this request straight to API without passing through our backend first.
