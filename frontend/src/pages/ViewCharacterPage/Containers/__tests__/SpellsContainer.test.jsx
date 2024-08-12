import * as React from "react";

import axios from "axios";

import { render, screen } from "@testing-library/react";
import { expect, it, jest } from "@jest/globals";
import "@testing-library/jest-dom";

import SpellContainer from "../SpellContainer";
jest.mock("axios");
const mSpellsList = [
  {
    SpellID: 1,
    SpellName: "fakeSpell1",
    SpellDamageType: "fake",
    SpellLevel: 2,
    SpellRange: "1",
  },
  {
    SpellID: 2,
    SpellName: "fakeSpell2",
    SpellDamageType: "fake",
    SpellLevel: 1,
    SpellRange: "3",
  },
  {
    SpellID: 3,
    SpellName: "fakeSpell3",
    SpellDamageType: "fake",
    SpellLevel: 1,
    SpellRange: "4",
  },
];

describe("spells container rendering", () => {
  it("renders all spells", () => {
    // arrange
    axios.get.mockImplementation(() => Promise.resolve({ data: mSpellsList }));

    //act
    render(<SpellContainer characterID={3} />);

    //assert
    // mSpellsList.forEach((spell) =>
    //   expect(screen.getByText(spell.SpellName)).toBeInTheDocument()
    // );
  });
});
