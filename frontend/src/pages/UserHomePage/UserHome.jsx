import React, { useContext, useEffect, useState } from 'react';
import HomeStyles from "../../Styles/HomeStyles.css"
// import NavBar from '../Components/NavBar';
import CharacterCard from '../../Components/HomeComps/CharacterCard';
import LandingButton from "../../Components/LandingComps/LandingButton";
import { useNavigate, useParams } from 'react-router-dom';
import getCharacters from '../../utilities/api/getCharacters';
import { UserContext } from '../../App';

function Home() {
    // get characters and things
    const navigate = useNavigate();

    const [characters, setCharacters] = useState([]);
    const {user, setUser} = useContext(UserContext);


    useEffect(()=> {
        fetchCharacters();
    }, [])

    const fetchCharacters = async() => {
        try{
            var res = await getCharacters(user.id);
            setCharacters(res);

        }catch(error){
            console.error(error);

        }
    }
    

    // TODO: replace with data for stuff
    const toCharacterSheet = (c) => {
        navigate(`/home/${user.firstName}/character-sheet/${c}`);
    }


    const mapCharacters = characters.map((c, index)=> 
        <CharacterCard key={index} onPress={toCharacterSheet} dndCharacter={c}/>
    );

    const onPressNavigate = () => {
        navigate("/character-creator");
    }



    return(
        <div className='home'>
            {/* <NavBar /> */}
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

                    <div className="card-box">
                    <div className="card-container">
                        <div className="card">
                            {characters.length > 0 ? mapCharacters: 
                            <div style={{justifySelf: 'center'}}>
                                <h1>No characters made yet! Create one today!</h1>
                            </div>
                            
                            }

                        </div>
                    </div>
                  

                </div>
                </div>
                
            </div>
           
        </div>
    )

}
export default Home;