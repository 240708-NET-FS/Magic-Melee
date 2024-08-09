// get all spells that a specific class can use
import axios from "axios";
import server from "./server";
const endpoint = "api/DndCharacter/spells/";
const deleteCharacterSpell = async (CharacterID, SpellID) => {
  const response = await axios.delete(
    server + endpoint + CharacterID + "/" + SpellID
  );
  return response.data;
};
export default deleteCharacterSpell;
// TODO: #9  if there's time , may pass this request straight to API without passing through our backend first.
