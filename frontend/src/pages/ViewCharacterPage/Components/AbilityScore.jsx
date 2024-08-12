import React, { useState } from "react";
const AbilityScore = ({ scoreName, scoreVal, handleChange, textColor }) => {
  return (
    <div
      className={
        "flex flex-col rounded-md border-2 border-black p-0 mx-2 min-w-0"
      }
    >
      {" "}
      <p className="underline text-md"> {scoreNames[scoreName]} </p>{" "}
      <input
        className={`self-center bg-transparent text-black text-center ${textColor}`}
        value={scoreVal}
        onChange={(e) => handleChange(scoreName, e.target.value)}
      />{" "}
    </div>
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
