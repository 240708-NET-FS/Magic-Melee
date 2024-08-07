import React from 'react';
import HomeStyles from "../Styles/HomeStyles.css"
import NavBar from '../Components/NavBar';
import CharacterCard from '../Components/HomeComps/CharacterCard';

function Home() {

    // get characters and things
    // const navigate = useNavigation();


    
    // map the cards

    const charactersTemp = [1, 2, 3, 4, 5, 6, 7, 8]

    const mapCharacters = charactersTemp.map((m, index)=> 
        <CharacterCard />
    );

    
    return(
        <div className='home'>
            <NavBar />
            {/* <h1>Home</h1> */}
            <div style={{padding: 75}}>
                <div className='user-charactersBox'>
                    <h2>My Characters</h2>
                </div>
                <div>
                    <div class="card-box">
                    <div class="card-container">
                        <div class="card">
                            {mapCharacters}

                        </div>



                    </div>
                  

                </div>
                </div>
                
            </div>
           
        </div>
    )

}
export default Home;