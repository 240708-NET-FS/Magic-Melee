import logo from './logo.svg';
import './App.css';
import React from 'react';
import {BrowserRouter as Router, createBrowserRouter, Route, RouterProvider, Routes} from 'react-router-dom';
import Landing from './Screens/Landing';
import Home from "./Screens/Home";
import AppNavigator from "./AppNavigator";
import {createRoot} from "react-dom/client";

function App() {

  // const router = createBrowserRouter([
  //   {
  //     path: "/",
  //     element: (
  //         <div>
  //           <h1>Landing</h1>
  //         </div>
  //     ),
  //
  //   },
  //   {
  //     path: "home",
  //     element: (
  //         <div>
  //           <h1>Home</h1>
  //         </div>
  //     )
  //   }
  //
  // ]);
  //
  // createRoot(document.getElementById("root")).render(
  //     <RouterProvider router={router} />
  // );


  return (
    <div className="App">
        <div className="App-header">
            <Router>
                <Routes>
                    <Route exact path={"/"} element={<Landing />} />
                    <Route exact path={"/home"} element={<Home/>}/>
                </Routes>
            </Router>
        </div>
    </div>
  );
}

export default App;
