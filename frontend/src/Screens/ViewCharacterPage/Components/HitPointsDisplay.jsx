import React, { useState } from "react";

const HitPointsDisplay = ({ HitPoints, MaxHitPoints, UpdateHitPoints }) => {
  const handleClick = (e) => {
    e.preventDefault();
    UpdateHitPoints(e.target.elements["HP"].value);
  };
  const [HP, UpdateHP] = useState(HitPoints);

  return (
    <section className="border-white border-4 text-black bg-purple-300 flex flex-col">
      <h3 className="underline"> Hit Points</h3>
      <form className="flex flex-col" onSubmit={handleClick}>
        <section className="flex flex-row justify-around">
          <p className="basis-2/5 flex flex-col align-middle">
            <label for="HP"> Current Hit Points</label>
            <input
              type="text"
              className="bg-transparent"
              value={HP}
              onChange={(e) => UpdateHP(e.target.value)}
              name="HP"
              id="HP"
            />
          </p>

          <p className="basis-1/5"> / </p>
          <section>
            {" "}
            <label for="MaxHP"> Max Hit Points </label>{" "}
            <p id="MaxHP" className="basis-2/5">
              {" "}
              {MaxHitPoints}{" "}
            </p>
          </section>
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
