import React, { useState } from "react";

const HitPointsDisplay = ({ HitPoints, MaxHitPoints, UpdateHitPoints }) => {
  const handleClick = (e) => {
    e.preventDefault();
    UpdateHitPoints(e.target.elements["HP"].value);
  };
  const [HP, UpdateHP] = useState(HitPoints);
  console.log("Max Hit Points:" + MaxHitPoints);
  return (
    <section className="border-white border-4 text-black bg-purple-300 flex flex-col">
      <h3 className="underline"> Hit Points</h3>
      <form className="flex flex-col" onSubmit={handleClick}>
        <section className="flex flex-row justify-around">
          <p className="basis-2/5">
            <input
              type="text"
              className="bg-transparent"
              value={HP}
              onChange={(e) => UpdateHP(e.target.value)}
              name="HP"
            />
          </p>

          <p className="basis-1/5"> / </p>

          <p className="basis-2/5"> {MaxHitPoints} </p>
        </section>

        <section>
          <input
            className="border-black bg-purple-500 rounded-md p-2"
            type="submit"
            value="Update HP"
          />
        </section>
      </form>
    </section>
  );
};

export default HitPointsDisplay;
