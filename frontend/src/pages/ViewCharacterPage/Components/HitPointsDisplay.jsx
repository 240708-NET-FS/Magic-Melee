import React, { useState } from "react";

const HitPointsDisplay = ({ HitPoints, MaxHitPoints, UpdateHitPoints }) => {
  const handleClick = (e) => {
    e.preventDefault();
    UpdateHitPoints(e.target.elements["HP"].value);
  };
  const [HP, SetHP] = useState(HitPoints);

  return (
    <section className="border-black border-4 text-black bg-purple-300 flex flex-col basis-1/5 rounded-md">
      <h3 className="underline"> Hit Points</h3>
      <form className="flex flex-col" onSubmit={handleClick}>
        <section className="flex flex-row items-stretch">
          {/* Section for HP input */}
          <section className="flex flex-col  basis-2/5">
            <label htmlFor="HP" className="text-sm">
              {" "}
              Current Hit Points
            </label>

            {/* Input field for HP value */}
            <input
              type="text"
              className="bg-transparent max-w-24 text-center"
              value={HP}
              onChange={(e) => SetHP(e.target.value)}
              name="HP"
              id="HP"
            />
          </section>

          <section className="basis-1/5 grow text-center"> / </section>

          {/* Max HP Section  */}
          <section className="basis-2/5">
            {" "}
            <label htmlFor="MaxHP" className="text-sm">
              {" "}
              Max Hit Points{" "}
            </label>{" "}
            <p id="MaxHP" className="">
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
