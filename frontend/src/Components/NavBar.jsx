import React, { useState, useEffect, useContext } from 'react';
import ComponentStyles from "../Styles/ComponentStyles.css";
import { useLocation, useNavigate } from 'react-router-dom';
import { UserContext } from '../App';



function NavBar(){

    const location = useLocation();
    const {hash, pathname, search} = location;

    const {user, setUser} = useContext(UserContext);

    const [current, setCurrent] = useState(location);
    const [showNav, setShowNav] = useState(true);

    const navigate = useNavigate();

    
    useEffect(()=> {
        console.log(user);
    }, [user])

    useEffect(()=> {
        if(location.pathname === "/"){
            setShowNav(false);
        }else{
            setShowNav(true);
        }
    }, [location])


    const logout = () => {
        setUser(null);
        navigate("/");
    }


    return(
        showNav ?
        <div className="navbar-position">
            <div className="navbar-base">
                <div className='navbar-contentWrap'>
                    <div className='navlink' style={{justifySelf: 'left', padding: 10}} onClick={()=> navigate("/")}>
                        <h2 style={{fontWeight: 'bold', color: 'white', fontSize: "100%"}}>Magic & Melee</h2>
                    </div>
                    <div style={{flexDirection: 'row', position: 'absolute', right: 0}}>

                        <ul style={{display: 'inline-flex', justifyContent: 'space-between', flexBasis: '30%', flexWrap: 'wrap'}}>
                            <div id={'navlink1'} className='navlink' >         
                                <div onClick={()=> navigate(`/character-creator`)}>
                                    <li style={{padding: 10}}>Create Character</li>
                                </div>                   
                            </div>
                            {/* <div id={'navlink2'} className='navlink'>
                                <li style={{padding: 10}}>View Characters</li>
                            </div> */}

                            {user ? 
                            <div style={{flexDirection: 'row', display: 'inline-flex'}}>
                                <div id={'navlink3'} className='navlink'  onClick={()=> navigate(`/home/${user.firstName}`)}>
                                    <li style={{padding: 10}}>Home</li>
                                </div>
                                <div id={'navlink4'} className='navlink'  onClick={logout}>
                                    <li style={{padding: 10}}>Logout</li>
                                </div>
                            </div>
                            : null}
                            
                        </ul>
                       
                    </div>
                   
                    <div style={{right: 10, position: 'absolute'}}>
                        <div style={{position: 'relative'}}>
                            <div style={{display: 'flex', flexDirection: 'row'}}>
                                
                            </div>
                        

                        </div>

                    </div>
                </div>
              
            </div>


        </div>: null
    )
}

export default NavBar;