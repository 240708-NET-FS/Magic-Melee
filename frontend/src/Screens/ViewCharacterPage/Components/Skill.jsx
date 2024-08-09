import React from "react";

const Skill = ({ skillName, skillVal, handleChange, textColor }) => {
  return (
    <section className="flex flex-row justify-between border-white border-2 rounded-md">
      {" "}
      <h2 className=""> {skillName} </h2>{" "}
      <input
        className={`bg-transparent justify-self-end ${textColor}`}
        value={skillVal}
        onChange={(e) => handleChange(skillName, e.target.value)}
      />{" "}
    </section>
  );
};

export default Skill;
