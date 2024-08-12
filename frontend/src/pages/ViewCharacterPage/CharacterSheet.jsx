import React from "react";
import NameAndStatusContainer from "./Containers/NameAndStatusContainer";
import AbilityScoreContainer from "./Containers/AbilityScoreContainer";
//import ArmorClass from "./Components/ArmorClass";
import SkillsContainer from "./Containers/SkillsContainer";

import SpellContainer from "./Containers/SpellContainer";
import { useParams } from "react-router-dom";
// components :
// NameAndStatusContainer
// StatsContainer
// SkillsContainer
// InventoryContainer

const CharacterSheet = ({ character }) => {
  // default character is hoisted from below

  return (
    <section className="bg-purple-900 flex flex-col justify-center w-full">
      <NameAndStatusContainer character={character} />
      <section className="flex flex-row justify-stretch">
        <AbilityScoreContainer
          characterID={character ? character.characterId : 3}
          abilityScoreID={character ? character.abilityScoreArrId : 1}
        />
        {/* <ArmorClass value={char? } /> */}
      </section>

      <section className="flex flex-row justify-stretch">
        <SkillsContainer
          characterID={character ? character.characterId : 3}
          skillsID={character ? character.skillsID : 1}
        />
        <SpellContainer characterID={character ? character.characterId : 3} />
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
