import React, { useEffect, useState } from "react";
import Skill from "../Components/Skill";
import validateSkill from "../util/validateSkill";

const SkillsContainer = () => {
  const [skills, setSkills] = useState(defaultSkills);

  const handleChange = (name, val) => {
    const newSkills = { ...skills };
    newSkills[name] = val;
    setSkills(newSkills);
  };

  const SkillComponentArr = Object.getOwnPropertyNames(defaultSkills).map(
    (name) => {
      const textColor = validateSkill(skills[name])
        ? "text-white"
        : "text-red-600";
      return (
        <Skill
          skillName={name}
          skillVal={skills[name]}
          handleChange={handleChange}
          textColor={textColor}
        />
      );
    }
  );

  // effect hook to retrieve skills from daatbase
  useEffect(() => {
    setSkills((skills) => setRandomSkillValues(skills));
  }, []);

  // effect hook with api call to update will go here
  useEffect(() => {}, [skills]);

  return (
    <section className="flex flex-col border-black border-2 rounded-md basis-1/2 items-stretch">
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

function setRandomSkillValues(skills) {
  const skillsCopy = { ...skills };
  Object.getOwnPropertyNames(skills).forEach(
    (name) => (skillsCopy[name] = Math.floor(Math.random() * 20))
  );
  return skillsCopy;
}
export default SkillsContainer;
