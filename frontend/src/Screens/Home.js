import React from 'react';
import HomeStyles from "../Styles/HomeStyles.css"
import NavBar from '../Components/NavBar';
import CharacterCard from '../Components/HomeComps/CharacterCard';
import LandingButton from "../Components/LandingComps/LandingButton";
import { useNavigate } from 'react-router-dom';

function Home() {

    // get characters and things
    const navigate = useNavigate();
    
    // map the cards


    // TODO: replace with data for stuff
    const charactersTemp = [1, 2, 3, 4, 5, 6, 7, 8]

    const mapCharacters = charactersTemp.map((m, index)=> 
        <CharacterCard />
    );

    const onPressNavigate = () => {
        navigate("/character-creator");
    }

    return(
        <div className='home'>
            <NavBar />
            {/* <h1>Home</h1> */}
            <div style={{padding: 75}}>
                  
              
                <div style={{width: '100%'}}>
                    <div style={{  alignItems: 'center'}}>
                        <div>
                            <div className='user-charactersBox'>
                                        <h2>My Characters</h2>
                                    </div>
                
                                <div style={{textAlign: 'right'}}>
                                    <div className='create-button'>
                                        <LandingButton
                                                radius={4}
                                                color={"#480355"}
                                                text={"Create a Character"}
                                                borderColor={"black"}
                                                borderWidth={2}
                                                size={250}
                                                onPress={onPressNavigate}
                                            />
                                    </div>
                                    
                            </div>
                        </div>
                            
                        
                    </div>

                    
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