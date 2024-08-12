import * as React from "react";

import axios from "axios";

import { render, screen } from "@testing-library/react";
import { expect, it, jest } from "@jest/globals";
import "@testing-library/jest-dom";

import SkillsContainer, { defaultSkills } from "../SkillsContainer";
import { skillDisplayNames } from "../../Components/Skill";
jest.mock("axios");
describe("Skills Container rendering", () => {
  it("renders all skills with proper display names", () => {
    axios.get.mockImplementation((characterID) =>
      Promise.resolve({ data: { skillsId: 1, ...defaultSkills } })
    );
    axios.put.mockImplementation((scores) =>
      Promise.resolve({ skillsId: 1, ...scores })
    );
    // act
    render(<SkillsContainer characterID={3} skillsID={1} />);
    
    // assert
    Object.values(skillDisplayNames).forEach((name) =>
      expect(screen.getByText(name)).toBeInTheDocument()
    );
  });
});
