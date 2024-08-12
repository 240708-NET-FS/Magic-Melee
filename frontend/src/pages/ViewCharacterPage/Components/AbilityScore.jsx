import React, { useState } from "react";
const AbilityScore = ({ scoreName, scoreVal, handleChange, textColor }) => {
  return (
    <section
      className={"flex flex-col rounded-md border-2 border-black mr-2 shrink"}
    >
      {" "}
      <h2 className="underline"> {scoreNames[scoreName]} </h2>{" "}
      <input
        className={`self-center bg-transparent text-black text-center ${textColor}`}
        value={scoreVal}
        onChange={(e) => handleChange(scoreName, e.target.value)}
      />{" "}
    </section>
  );
};

const scoreNames = {
  str: "Strength",
  dex: "Dexterity",
  con: "Constitution",
  int: "Intelligence",
  wis: "Wisdom",
  cha: "Charisma",
};

export default AbilityScore;
