// expects a list of characters tied to user to display
import axios from "axios";
const server = "http://localhost:3000/";
const endpoint = "api/items?characterid=";
const getInventory = async (charID) => {
  const response = await axios.get(server + endpoint + charID);
  return response.data;
};

export default getInventory;
