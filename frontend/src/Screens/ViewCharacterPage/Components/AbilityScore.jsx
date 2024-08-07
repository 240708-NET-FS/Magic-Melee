import React from "react";
// TODO: #10 add reactivity
const AbilityScore = ({ scoreName, scoreVal, handleChange }) => {
  return (
    <section className="flex flex-col border-white border-2 rounded-md mr-5">
      {" "}
      <h2 className="border-black underline"> {scoreName} </h2>{" "}
      <input
        className="bg-transparent"
        value={scoreVal}
        onChange={(e) => handleChange(scoreName, e.target.value)}
      />{" "}
    </section>
  );
};

export default AbilityScore;
