import React, { useEffect, useState } from "react";
import Skill from "../Components/Skill";
import validateSkill from "../util/validateSkill";
import { getSkills, putSkills } from "../../../utilities/api";

const SkillsContainer = ({ characterID, skillsID }) => {
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
    getSkills(characterID).then((skillObj) => {
      delete skillObj.skillsId;
      setSkills(skillObj);
    });
    // setSkills((skills) => setRandomSkillValues(skills));
  }, [characterID]);

  // effect hook with api call to update will go here
  useEffect(() => {
    let skillNums = {};
    Object.keys(skills).forEach(
      (name) => (skillNums[name] = Number(skills[name]))
    );

    let skillsAreValid = true;
    Object.values(skillNums).forEach((skill) => {
      //console.log("skill: ", skill, validateSkill(skill));
      skillsAreValid = skillsAreValid && validateSkill(skill);
    });
    if (!skillsAreValid) return;

    if (!(JSON.stringify(skills) === JSON.stringify(defaultSkills))) {
      // if scores are valid then update database
      const skillsObj = {
        skillsId: skillsID,
        ...skillNums,
      };
      putSkills(skillsObj);
    }
  }, [skills, skillsID]);

  return (
    <section className="flex flex-col border-black border-2 rounded-md basis-1/2 items-stretch">
      {SkillComponentArr}
    </section>
  );
};

const defaultSkills = {
  acrobatics: 0,
  animalHandling: 0,
  arcana: 0,
  athletics: 0,
  deception: 0,
  history: 0,
  insight: 0,
  intimidation: 0,
  investigation: 0,
  medicine: 0,
  nature: 0,
  perception: 0,
  performance: 0,
  persuasion: 0,
  religion: 0,
  sleightOfHand: 0,
  stealth: 0,
  survival: 0,
};

// function setRandomSkillValues(skills) {
//   const skillsCopy = { ...skills };
//   Object.getOwnPropertyNames(skills).forEach(
//     (name) => (skillsCopy[name] = Math.floor(Math.random() * 20))
//   );
//   return skillsCopy;
// }
export default SkillsContainer;
export { defaultSkills };
