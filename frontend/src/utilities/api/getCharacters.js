// expects a list of character DTOs tied to user id to display
import axios from "axios";
import server from "./server";

const endpoint = "api/Dndcharacter/user/";
const getCharacters = async (userID) => {
  const response = await axios.get(server + endpoint + userID);
  return response.data;
};

export default getCharacters;
