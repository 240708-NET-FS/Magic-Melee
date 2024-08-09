import React, { useState, useEffect } from 'react';
import ComponentStyles from "../Styles/ComponentStyles.css";
import { useLocation } from 'react-router-dom';



function NavBar(){

    const location = useLocation();
    const {hash, pathname, search} = location;

    const [current, setCurrent] = useState(location);
    const [showNav, setShowNav] = useState(true);

    
    
    const onPressNavigate = (element) => {

    }

    useEffect(()=> {
        console.log(location.pathname)
        if(location.pathname === "/"){
            setShowNav(false);
        }else{
            setShowNav(true);
        }
    }, [location])


    return(
        showNav ?
        <div className="navbar-position">
            <div className="navbar-base">
                <div className='navbar-contentWrap'>
                    <div style={{justifySelf: 'left', padding: 10}}>
                        <h2 style={{fontWeight: 'bold', color: 'white', fontSize: "100%"}}>Magic & Melee</h2>
                    </div>
                    <div style={{flexDirection: 'row', position: 'absolute', right: 0}}>

                        <ul style={{display: 'inline-flex', justifyContent: 'space-between', flexBasis: '30%', flexWrap: 'wrap'}}>
                            <div id={'navlink1'} className='navlink' >         
                                <div onClick={()=> onPressNavigate()}>
                                    <li style={{padding: 10}}>Create Character</li>
                                </div>                   
                            </div>
                            <div id={'navlink2'} className='navlink'>
                                <li style={{padding: 10}}>View Characters</li>
                            </div>
                            <div id={'navlink3'} className='navlink'>
                                <li style={{padding: 10}}>Home</li>
                            </div>
                            
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