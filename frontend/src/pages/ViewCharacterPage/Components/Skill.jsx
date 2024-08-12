import React from "react";

const Skill = ({ skillName, skillVal, handleChange, textColor }) => {
  return (
    <section className="flex flex-row justify-between border-white border-2 rounded-md">
      {" "}
      <h2 className=""> {displayNames[skillName]} </h2>{" "}
      <input
        className={`bg-transparent justify-self-end ${textColor}`}
        value={skillVal}
        onChange={(e) => handleChange(skillName, e.target.value)}
      />{" "}
    </section>
  );
};

const displayNames = {
  acrobatics: "Acrobatics",
  animalHandling: "Animal Handling",
  arcana: "Arcana",
  athletics: "Athletics",
  deception: "Deception",
  history: "History",
  insight: "Insight",
  intimidation: "Intimidation",
  investigation: "Investigation",
  medicine: "Medicine",
  nature: "Nature",
  perception: "Perception",
  performance: "Performance",
  persuasion: "Persuasion",
  religion: "Religion",
  sleightOfHand: "Sleight of Hand",
  stealth: "Stealth",
  survival: "Survival",
};
export default Skill;
