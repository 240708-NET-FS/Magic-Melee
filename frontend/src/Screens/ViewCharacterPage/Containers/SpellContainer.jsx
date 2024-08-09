import React, { useState, useEffect } from "react";
import Spell from "../Components/Spell";
const SpellContainer = ({ userID }) => {
  const [spells, setSpells] = useState([]);

  return (
    <section className="flex flex-col items-stretch border-2 ml-5 basis-2/5 rounded-md">
      <p className="basis-1/12 self-center">
        <h2 className="italic text-center"> Spells</h2>
      </p>
    </section>
  );
};


const getUserSpells= () => {
  
}
export default SpellContainer;
