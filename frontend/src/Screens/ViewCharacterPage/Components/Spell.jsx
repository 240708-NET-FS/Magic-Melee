import React from "react";
import SpellDelete from "./DeleteButton";

const Spell = ({
  handleDelete,
  SpellName,
  SpellRange,
  SpellLevel,
  SpellDamageType,
}) => {
  return (
    <tr>
      <th scope="row"> {SpellName} </th>
      <td> {SpellLevel} </td>
      <td> {SpellRange} </td>
      <td> {SpellDamageType} </td>
      <td>
        {" "}
        <SpellDelete />
      </td>
    </tr>
  );
};

export default Spell;
