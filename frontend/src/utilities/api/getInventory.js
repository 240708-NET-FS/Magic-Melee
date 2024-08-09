// expects a list of characters tied to user to display
import axios from "axios";
import server from "./server";
const endpoint = "api/items/character";
const getInventory = async (charID) => {
  const response = await axios.get(server + endpoint + charID);
  return response.data;
};

export default getInventory;
