import React from "react";

const SpellDelete = ({ handleClick }) => {
  return (
    <button className="bg-red-400" onClick={handleClick}>
      {" "}
      Delete{" "}
    </button>
  );
};

export default SpellDelete;
