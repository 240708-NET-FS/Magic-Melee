import React, { useEffect, useState } from "react";
import AbilityScore from "../Components/AbilityScore";
const AbilityScoreContainer = ({ charID }) => {
  // will need to use an effect hook to get ability scores
  const [scores, updateScores] = useState(defaultScores);

  const handleChange = (name, val) => {
    
    const newScores = { ...scores };
    newScores[name] = val;
    updateScores(newScores);
  };

  let scoreArr = scoreNameArr.map((name) => (
    <AbilityScore
      scoreName={name}
      scoreVal={scores[name]}
      handleChange={handleChange}
    />
  ));

  useEffect(() => {
    scoreArr = scoreNameArr.map((name) => (
      <AbilityScore
        scoreName={name}
        scoreVal={scores[name]}
        handleChange={handleChange}
      />
    ));
    // TODO: #11 create updateAbilityScores API request and call here
  }, [scores]);

  return (
    <section className="basis:2/5 grow">
      <section className="flex flex-row justify-between  mr-20">
        {" "}
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
export default AbilityScoreContainer;
