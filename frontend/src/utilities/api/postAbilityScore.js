// expects a list of characters tied to user to display
import axios from "axios";
import server from "./server";
const endpoint = "api/AbilityScoreArr";

const postAbilityScores = async (abilityScores) => {
    console.log(abilityScores);
    const response = await axios.post(server + endpoint, abilityScores);
    return response.data;
}

export default postAbilityScores;