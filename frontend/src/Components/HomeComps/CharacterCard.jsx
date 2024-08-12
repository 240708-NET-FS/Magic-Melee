import React, { useEffect, useState } from 'react';
import {Button} from "@mui/material";
import { getClass } from '../../utilities/api';


const CharacterCard = ({onPress, dndCharacter, key}) => {

    const [charClass, setCharClass] = useState(null); 

    useEffect(()=> {

        const fetchClass = async()=> {
            try{
                var c = await getClass(dndCharacter.characterClassId);
                setCharClass(c);
            }catch(error){
                console.error(error);
            }
        }

        fetchClass();

    }, [])

        return(
            <Button
                sx={{
                    color: 'white',
                    textTransform: "none"
                }}
                onClick={()=> onPress(dndCharacter.characterName)}
                
            >
                <div className='cardBase'>
                    <div className='card-base2'>
                        <div>


                        </div>
                        <div>
                            <div className='card-bottomWrapper'>
                                <div className="card-bottom">
                                        <div style={{paddingLeft: 5}}>
                                            <div>
                                                <p style={{fontSize: 18, fontWeight: "bold", margin: 0, paddingTop: 5}}>{dndCharacter.characterName}</p>
                                                <p style={{margin: 0}}>Hit Points: {dndCharacter.hitPoints}</p>
                                                <p style={{margin: 0}}>{charClass ? charClass.name: null}</p>

                                            </div>
                    
                                        </div>
                                        <div style={{display: 'flex', paddingLeft: 5}}>
                                        </div>

                                </div>
                               
                      

                            </div>
                           
                        </div>
                        
                    </div>
               
            </div>
            </Button>

        )
    
}

export default CharacterCard;