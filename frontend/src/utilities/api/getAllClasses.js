import axios from "axios";
import server from "./server";
const endpoint = "api/classes";
const getAllClasses = async () => {
  const response = await axios.get(server + endpoint);
  return response.data;
};
export default getAllClasses;
