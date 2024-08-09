import * as React from "react";

import { render, screen } from "@testing-library/react";
import { test, expect, it, jest } from "@jest/globals";
import "@testing-library/jest-dom";
import { defaultCharacter } from "../../CharacterSheet";
import HitPointsDisplay from "../HitPointsDisplay";
import userEvent from "@testing-library/user-event";

describe("Hit Point updates", () => {
  test("Hit Point update shows on page", async () => {
    // arrange
    const updateHP = jest.fn();
    render(
      <HitPointsDisplay
        HitPoints={defaultCharacter.HitPoints}
        MaxHitPoints={defaultCharacter.MaxHitPoints}
        UpdateHitPoints={updateHP}
      />
    );

    // act: udpdate hp with a user event
    userEvent.clear(screen.getByDisplayValue(defaultCharacter.HitPoints));

    let InputField = screen.getByLabelText("Current Hit Points");
    userEvent.paste(InputField, "16");
    InputField = screen.getByLabelText("Current Hit Points");
    expect(InputField.value).toEqual("16");
  });

  test("Hit Point update button fires handler", async () => {
    // arrange
    const updateHP = jest.fn();
    render(
      <HitPointsDisplay
        HitPoints={defaultCharacter.HitPoints}
        MaxHitPoints={defaultCharacter.MaxHitPoints}
        UpdateHitPoints={updateHP}
      />
    );

    // act: udpdate hp with a user event
    userEvent.clear(screen.getByDisplayValue(defaultCharacter.HitPoints));
    userEvent.paste(screen.getByLabelText("Current Hit Points"), "16");
    userEvent.click(screen.getByText("Update HP"));

    expect(updateHP).toBeCalledWith("16");
  });
});
