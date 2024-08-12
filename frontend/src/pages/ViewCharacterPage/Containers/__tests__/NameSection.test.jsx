import * as React from "react";
import axios from "axios";

import { render, screen } from "@testing-library/react";
import { test, expect, it, jest } from "@jest/globals";
import "@testing-library/jest-dom";
import NameAndStatusContainer from "../NameAndStatusContainer";
import { defaultCharacter } from "../../CharacterSheet";
import userEvent from "@testing-library/user-event";

jest.mock("axios");
describe("name display rendering ", () => {
  it("renders with default info if no API data provided", () => {
    // Arrange
    const textToBeExpected = `Level ${defaultCharacter.Level} ${defaultCharacter.Race} ${defaultCharacter.Class}`;

    // Act
    render(<NameAndStatusContainer />);

    // Assert
    expect(screen.getByText(textToBeExpected)).toBeInTheDocument();
  });

  it("renders with props if provided", () => {
    const mockCharacter = {
      Name: "Elizabeth",
      Level: 10,
      Class: "Bard",
      Race: "Tiefling",
    };
    const textToBeExpected = `Level ${mockCharacter.Level} ${mockCharacter.Race} ${mockCharacter.Class}`;

    render(<NameAndStatusContainer character={mockCharacter} />);
    expect(screen.getByText(textToBeExpected)).toBeInTheDocument();
  });
});
