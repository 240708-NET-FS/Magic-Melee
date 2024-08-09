import React from "react";
const NameSection = ({ Name, Race, Class, Level }) => {
  return (
    <section className="flex flex-col border-black border-4 bg-purple-300 text-black text-wrap justify-center rounded-md">
      <h2 className="bold justify-self-start">{Name}</h2>

      <section id="charDescription">
        Level {Level} {Race} {Class}
      </section>
    </section>
  );
};

export default NameSection;
