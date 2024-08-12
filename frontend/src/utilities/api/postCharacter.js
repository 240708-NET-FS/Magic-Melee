import axios from "axios";
import server from "./server";
const endpoint = "api/DndCharacter";

const postCharacter = async (name, hitPoints, maxHitPoints, userId, raceId, classId, asArrId, skillsId, spellsIds) => {

    const response = await axios.post(server + endpoint,
        {
            characterName: name,
            hitPoints: 16,
            maxHitPoints: 16,
            userId: userId,
            characterRaceId: raceId,
            characterClassId: classId,
            abilityScoreArrId: asArrId,
            skillsId: skillsId,
            spellsIds: spellsIds

        } 
    )
};

export default postCharacter;