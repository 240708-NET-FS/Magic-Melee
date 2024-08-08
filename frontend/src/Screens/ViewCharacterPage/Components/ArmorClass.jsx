import React from "react";
const ArmorClass = ({ value }) => {
  return (
    <section className="flex flex-col border-white border-2 rounded-md basis: 2/5 grow ml-2">
      {" "}
      <h2 className="border-black underline"> Armor Class </h2> <p> {value}</p>{" "}
    </section>
  );
};

export default ArmorClass;
