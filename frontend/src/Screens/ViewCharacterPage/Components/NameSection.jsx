import React from "react";
const NameSection = ({ Name, Race, Class, Level }) => {
  return (
    <section className="flex flex-col border-white rounded-sm bg-purple-300 text-black text-wrap">
      <h2 className="bold">{Name}</h2>

      <section id="charDescription">
        Level {Level} {Race} {Class}
      </section>
    </section>
  );
};

export default NameSection;
