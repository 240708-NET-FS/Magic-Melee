import React from "react";
const AbilityScore = ({ scoreName, scoreVal }) => {
  return (
    <section className="flex flex-col border-white border-2 rounded-md mr-5">
      {" "}
      <h2 className="border-black underline"> {scoreName} </h2>{" "}
      <p> {scoreVal}</p>{" "}
    </section>
  );
};

export default AbilityScore;
