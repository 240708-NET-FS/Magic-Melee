import React from "react";
const NameSection = ({ Name, Race, Class, Level }) => {
  return (
    <section className="flex flex-col border-white rounded-sm bg-purple-300 text-black">
      <h2 className="bold">{Name}</h2>

      <section id="charDescription">
        Level {Level} <span className="italic"> {Race} </span> {Class}
      </section>
    </section>
  );
};

export default NameSection;
