import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
const SpellDelete = ({ handleClick }) => {
  return (
    <button className="bg-purple-400 rounded-md p-1" onClick={handleClick}>
      {" "}
      <FontAwesomeIcon icon={faTrash} color="black" />{" "}
    </button>
  );
};

export default SpellDelete;
