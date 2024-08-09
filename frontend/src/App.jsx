import logo from './logo.svg';
import './App.css';
import React, { useEffect, useState, useRef} from 'react';
import {BrowserRouter as Router, createBrowserRouter, Route, RouterProvider, Routes, } from 'react-router-dom';
import Landing from './Screens/Landing';
import Home from "./Screens/Home";
import UserHome from "./Screens/UserHome";
import CharacterSheet from './Screens/ViewCharacterPage';
import CharacterCreator from "./Screens/CharacterCreator";
import AppNavigator from "./AppNavigator";
import {createRoot} from "react-dom/client";
import NavBar from './Components/NavBar';

function App() {
  const [showNav, setShowNav] = useState(false);


  const currentPage = useRef("/");
  



  

  useEffect(()=> {
    
  }, [])



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
       
       
        <div >
        
            <Router>
                <div>
                  <NavBar />
              </div>
                <Routes>
                    <Route exact path={"/"} element={<Landing />} />
                    <Route exact path={"/home/user/character/character-sheet"} element={<CharacterSheet />}/>
                    <Route exact path={"/home/user"} element={<UserHome />} />
                    <Route exact path={"/character-creator"} element={<CharacterCreator />} />
                </Routes> 
            </Router>
        </div>
    </div>
  );
}

export default App;
