import React, { useState } from "react";
import NameAndStatusContainer from "./Containers/NameAndStatusContainer";
import AbilityScoreContainer from "./Containers/AbilityScoreContainer";
import ArmorClass from "./Components/ArmorClass";
import SkillsContainer from "./Containers/SkillsContainer";
import InventoryContainer from "./Containers/InventoryContainer";
import SpellContainer from "./Containers/SpellContainer";
// components :
// NameAndStatusContainer
// StatsContainer
// SkillsContainer
// InventoryContainer

const CharacterSheet = () => {
  // default character is hoisted from below
  const [character, updateCharacter] = useState(defaultCharacter);

  return (
    <section className="bg-purple-900 flex flex-col justify-center w-full">
      <NameAndStatusContainer character={character} />
      <section className="flex flex-row justify-stretch">
        <AbilityScoreContainer characterID={3} />
        <ArmorClass value={10} />
      </section>

      <section className="flex flex-row justify-stretch">
        <SkillsContainer characterID={3} />
        <SpellContainer characterID={3} />
      </section>
    </section>
  );
};

export default CharacterSheet;

const defaultCharacter = {
  Name: "Sunsaint",
  Race: "Human",
  Class: "Paladin",
  Level: 2,
  HitPoints: 17,
  MaxHitPoints: 17,
};

export { defaultCharacter };
