import * as React from "react";

import axios from "axios";

import { render, screen } from "@testing-library/react";
import { test, expect, it, jest } from "@jest/globals";
import "@testing-library/jest-dom";

import AbilityScoreContainer, { defaultScores } from "../AbilityScoreContainer";
import { scoreNames } from "../../Components/AbilityScore";
jest.mock("axios");
describe("Ability Score Container rendering", () => {
  it("renders scores with proper display names", () => {
    axios.get.mockImplementation((characterID) =>
      Promise.resolve({ data: { abilityScoreArrId: 1, ...defaultScores } })
    );
    axios.put.mockImplementation((scores) =>
      Promise.resolve({ abilityScoreArrId: 1, ...scores })
    );
    // act
    render(<AbilityScoreContainer characterID={3} abilityScoreID={1} />);

    Object.values(scoreNames).forEach((name) =>
      expect(screen.getByText(name)).toBeInTheDocument()
    );
  });
});
