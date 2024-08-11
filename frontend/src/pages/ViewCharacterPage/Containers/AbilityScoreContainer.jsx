import React, { useState, useEffect } from "react";
import AbilityScore from "../Components/AbilityScore";
import validateScore from "../util/validateScore";
import { getAbilityScores } from "../../../utilities/api";

const AbilityScoreContainer = ({ characterID }) => {
  // TODO: will need to use an effect hook to get ability scores from backend API
  const [scores, setScores] = useState(defaultScores);

  const handleChange = (name, val) => {
    const newScores = { ...scores };
    newScores[name] = val;
    setScores(newScores);
  };

  const scoreArr = scoreNameArr.map((name, index) => {
    const textColor = validateScore(scores[name])
      ? "text-white"
      : "text-red-600";
    return (
      <AbilityScore
        scoreName={scoreNames[name]}
        scoreVal={scores[name]}
        handleChange={handleChange}
        textColor={textColor}
      />
    );
  });

  // API call to set values from database will go here
  useEffect(() => {
    getAbilityScores(characterID).then((scoreObj) => {
      delete scoreObj.abilityScoreArrId;
      console.log("scores", scoreObj);
      setScores(scoreObj);
    });
    //setScores((scores) => setRandomAbilityValues(scores));
  }, []);

  // API call to update will go here
  useEffect(() => {}, [scores]);

  return (
    <section className=" shrink">
      <section className="flex flex-row justify-between">
        {/*Render ability score component list */}
        {scoreArr}
      </section>
    </section>
  );
};

const defaultScores = {
  str: 1,
  dex: 1,
  con: 1,
  int: 1,
  wis: 1,
  cha: 1,
};
const scoreNames = {
  str: "Strength",
  dex: "Dexterity",
  con: "Constitution",
  int: "Intelligence",
  wis: "Wisdom",
  cha: "Charisma",
};

const scoreNameArr = Object.getOwnPropertyNames(defaultScores);

function setRandomAbilityValues(scores) {
  const scoresCopy = { ...scores };
  Object.getOwnPropertyNames(scores).forEach(
    (name) => (scoresCopy[name] = Math.floor(Math.random() * 15))
  );
  return scoresCopy;
}

export default AbilityScoreContainer;
