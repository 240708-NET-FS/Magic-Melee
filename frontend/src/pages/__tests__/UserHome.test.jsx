import * as React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { render, screen } from "@testing-library/react";
import { test, expect, it, jest } from "@jest/globals";
import "@testing-library/jest-dom";
import UserHome from "../UserHomePage/UserHome";
import userEvent from "@testing-library/user-event";





describe("User home page route", () => {
    // render the router before each
    // const router = (
    //     <BrowserRouter basename="/home/"
    // )

    <BrowserRouter basename="/home/user">
        <Routes>
            <Route exact path={"/home/user"} element={<UserHome />}/>
        </Routes>
    </BrowserRouter>

    
    }
)
