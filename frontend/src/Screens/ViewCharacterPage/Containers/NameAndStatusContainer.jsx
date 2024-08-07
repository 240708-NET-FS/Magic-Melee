// NameAndStatusContainer should be passed character object or at least the following properties:
/* 
- name 
- race 
- class 
- level 
- max HP 
*/
import React from "react";
import NameSection from "../Components/NameSection";
import HitPointsDisplay from "../Components/HitPointsDisplay";

const NameAndStatusContainer = ({ character }) => {
  return (
    <section className="flex flex-row justify-around rounded-sm">
      <NameSection
        Name={character ? character.Name : defaultCharacter.Name}
        Race={character ? character.Race : defaultCharacter.Race}
        Level={character ? character.Level : defaultCharacter.Level}
        Class={character ? character.Class : defaultCharacter.Class}
      />

      <HitPointsDisplay
        HitPoints={character ? character.HitPoints : defaultCharacter.HitPoints}
        MaxHitPoints={
          character ? character.MaxHitPoints : defaultCharacter.MaxHitPoints
        }
        UpdateHitPoints={(hitPoints) => console.log(hitPoints)}
      />
    </section>
  );
};

const defaultCharacter = {
  Name: "Sunsaint",
  Race: "Human",
  Class: "Paladin",
  Level: 2,
  HitPoints: 17,
  MaxHitPoints: 17,
};

export { defaultCharacter };

export default NameAndStatusContainer;
