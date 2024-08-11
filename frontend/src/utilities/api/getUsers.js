import axios from "axios";
import server from "./server";
const endpoint = "api/user";
const getUsers = async() => {
    const response = await axios.get(server + endpoint);
    return response.data;
}

export default getUsers;


