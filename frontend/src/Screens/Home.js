import React from 'react';
import HomeStyles from "../Styles/HomeStyles.css"
import NavBar from '../Components/NavBar';
import CharacterCard from '../Components/HomeComps/CharacterCard';
// import { useState } from 'react';

function Home() {

    // const [loading, setLoading] = useState(null);



    //get users' cards and things

    

    // map the cards
    return(
        <div className='home'>
            {/* <h1>Home</h1> */}
            <div style={{padding: 75}}>
                <div className='user-charactersBox'>
                    <h2>My Characters</h2>
                </div>

                
                <div class="card-box">
                    <CharacterCard />

                </div>
            </div>
           
        </div>
    )

}
export default Home;