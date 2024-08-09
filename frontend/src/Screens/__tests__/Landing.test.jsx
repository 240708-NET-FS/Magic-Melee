import * as React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { render, screen } from "@testing-library/react";
import { test, expect, it, jest } from "@jest/globals";
import "@testing-library/jest-dom";
import Landing from "../Landing";
import userEvent from "@testing-library/user-event";

describe("Landing page route", () => {
  // render the router before each
  const router = (
    <BrowserRouter basename="/">
      <Routes>
        <Route exact path={"/"} element={<Landing />} />
      </Routes>
    </BrowserRouter>
  );

  it("contains Login button", () => {
    render(router);
    expect(screen.getByText("Login")).toBeInTheDocument();
  });

  it("contains Create Account button", () => {
    render(router);
    expect(screen.getByText("Create Account")).toBeInTheDocument();
  });

  test("Create Account Button button press calls onPressCreate", () => {
    // arrange
    // render component
    render(router);
    // create jest spy for console.log
    const consoleSpy = jest.spyOn(console, "log");

    // act: simulate user click for login button
    userEvent.click(screen.getByText("Create Account"));

    // assert: should log to console 'hello old user'
    expect(consoleSpy).toHaveBeenCalledWith("hello new user");
  });
});
