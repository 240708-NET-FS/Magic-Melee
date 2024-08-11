import React, { useState, useEffect } from "react";
import Spell from "../Components/Spell";
import {
  getCharacterSpells,
  deleteCharacterSpell,
} from "../../../utilities/api";
const SpellContainer = ({ characterID }) => {
  const [spells, setSpells] = useState([]);

  const spellComponents = spells.map((spell) => {
    const handleDelete = async () => {
      await deleteCharacterSpell(characterID, spell.SpellID);
      getSpells(characterID).then((spellList) => setSpells(spellList));
    };
    return (
      <Spell
        handleDelete={handleDelete}
        SpellName={spell.SpellName}
        SpellRange={spell.SpellRange}
        SpellLevel={spell.SpellLevel}
        SpellDamageType={spell.SpellDamageType}
      />
    );
  });
  // once on mount, get all char spells
  useEffect(() => {
    getSpells(characterID).then((spellList) => {
      setSpells(spellList);
    });
  }, [characterID]);

  return (
    <section className="flex flex-col items-stretch border-2 ml-5 basis-2/5 rounded-md">
      <table>
        <thead>
          <tr>
            <th scope="col"> Spell Name </th>
            <th scope="col"> Spell Level </th>
            <th scope="col"> Spell Range </th>
            <th scope="col"> Spell Damage Type </th>
          </tr>
        </thead>
        <tbody>{spellComponents}</tbody>
      </table>
    </section>
  );
};

const getSpells = async (characterID) => {
  return getCharacterSpells(characterID);
};
export default SpellContainer;
