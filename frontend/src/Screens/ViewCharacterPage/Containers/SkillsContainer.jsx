import React, { useState, useEffect } from "react";
import Skill from "../Components/Skill";

const SkillsContainer = () => {
  const [skills, updateSkills] = useState(defaultSkills);

  const handleChange = (name, val) => {
    const newSkills = { ...skills };
    newSkills[name] = val;
    updateSkills(newSkills);
  };

  let SkillComponentArr = Object.getOwnPropertyNames(defaultSkills).map(
    (name) => (
      <Skill
        skillName={name}
        skillVal={skills[name]}
        handleChange={handleChange}
      />
    )
  );
  useEffect(() => {
    SkillComponentArr = Object.getOwnPropertyNames(defaultSkills).map(
      (name) => (
        <Skill
          skillName={name}
          skillVal={skills[name]}
          handleChange={handleChange}
        />
      )
    );
  }, [skills]);

  return (
    <section className="flex flex-col border-black border-2 rounded-md basis-1/2">
      {SkillComponentArr}
    </section>
  );
};

const defaultSkills = {
  Acrobatics: 0,
  "Animal Handling": 0,
  Arcana: 0,
  Athletics: 0,
  Deception: 0,
  History: 0,
  Insight: 0,
  Intimidation: 0,
  Investigation: 0,
  Medicine: 0,
  Nature: 0,
  Perception: 0,
  Performance: 0,
  Persuasion: 0,
  Religion: 0,
  "Sleight of Hand": 0,
  Stealth: 0,
  Survival: 0,
};
export default SkillsContainer;
