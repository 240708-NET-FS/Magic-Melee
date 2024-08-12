import * as React from "react";
import { render, screen } from "@testing-library/react";
import { test, expect, it, jest } from "@jest/globals";
import "@testing-library/jest-dom";
import Spell from "../Spell";

import userEvent from "@testing-library/user-event";

describe("Spell Delete Button", () => {
  it("renders and calls the delete handler", () => {
    const mockHandler = jest.fn();
    render(
      <Spell
        SpellName="fakeSpell"
        SpellDamageType="fake"
        SpellLevel={2}
        SpellRange="1"
        handleDelete={mockHandler}
      />
    );
    expect(screen.getByRole("button")).toBeInTheDocument();
    userEvent.click(screen.getByRole("button"));
    expect(mockHandler).toHaveBeenCalled();
  });
});
