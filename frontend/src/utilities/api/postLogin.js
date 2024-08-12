import axios from "axios";
import server from "./server";
const endpoint = "Login/login";

const postLogin = async(username, password) => {
    const response = await axios.post(server + endpoint, {username: username, password: password} );
    return response.data;
};

export default postLogin;