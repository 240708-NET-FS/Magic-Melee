import React, { useState, useEffect } from "react";
import AbilityScore from "../Components/AbilityScore";
import validateScore from "../util/validateScore";

const AbilityScoreContainer = ({ charID }) => {
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
        scoreName={name}
        scoreVal={scores[name]}
        handleChange={handleChange}
        textColor={textColor}
      />
    );
  });

  // API call to set values from database will go here
  useEffect(() => {
    setScores((scores) => setRandomAbilityValues(scores));
  }, []);

  // API call to update will go here
  useEffect(() => {}, [scores]);

  return (
    <section className="basis:2/5 grow">
      <section className="flex flex-row justify-between  mr-20">
        {/*Render ability score component list */}
        {scoreArr}{" "}
      </section>
    </section>
  );
};

const defaultScores = {
  Strength: 1,
  Dexterity: 1,
  Constitution: 1,
  Intelligence: 1,
  Wisdom: 1,
  Charisma: 1,
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
