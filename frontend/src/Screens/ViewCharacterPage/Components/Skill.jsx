import React from "react";
// TODO: #10 add reactivity
const Skill = ({ skillName, skillVal, handleChange }) => {
  return (
    <section className="flex flex-row justify-between border-white border-2 rounded-md mr-5">
      {" "}
      <h2 className="border-black underline"> {skillName} </h2>{" "}
      <input
        className="bg-transparent justify-self-end"
        value={skillVal}
        onChange={(e) => handleChange(skillName, e.target.value)}
      />{" "}
    </section>
  );
};

export default Skill;
