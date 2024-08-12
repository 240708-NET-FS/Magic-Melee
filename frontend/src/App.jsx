import logo from './logo.svg';
import './App.css';
import React, { useEffect, useState, useRef} from 'react';
import {BrowserRouter as Router, createBrowserRouter, Route, RouterProvider, Routes, } from 'react-router-dom';
import Landing from './pages/Landing/Landing';
// import Home from ".pages/Home";
import UserHome from "./pages/UserHomePage/UserHome";
import CharacterSheet from './pages/ViewCharacterPage';
import CharacterCreator from "./pages/CharacterCreator/CharacterCreator";
import AppNavigator from "./AppNavigator";
import {createRoot} from "react-dom/client";
import NavBar from './Components/NavBar';


export const UserContext = React.createContext(null);

function App() {

  const [user, setUser] = useState(null);

  return (
    <div className="App">
        <div >
            <Router>
              <UserContext.Provider value={{user: user, setUser: setUser}}>
                  <div>
                    <NavBar />
                </div>
                  <Routes>
                      <Route exact path={"/"} element={<Landing />} />
                      <Route exact path={user ? `/home/${user.firstName}/character-sheet/:characterName`: null} element={<CharacterSheet/>} />
                      <Route exact path={user ? `/home/${user.firstName}` : "/home"} element={<UserHome />} />
                      <Route exact path={"/character-creator"} element={<CharacterCreator />} />
                  </Routes> 
                </UserContext.Provider>
            </Router>
        </div>
    </div>
  );
}

export default App;
