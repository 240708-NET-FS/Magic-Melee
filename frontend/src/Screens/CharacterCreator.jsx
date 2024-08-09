import React, { useEffect, useRef, useState } from "react";
import CharacterCreatorStyles from "../Styles/CharacterCreatorStyles.css";
import bg2 from "../Assets/m&mbg2.jpg"
import ListItem from "../Components/CharacterCreatorComps/ListItem";
import LandingButton from "../Components/LandingComps/LandingButton";
import NavBar from "../Components/NavBar";
import AbilityScore from "../Components/CharacterCreatorComps/AbilityScore";


function CharacterCreator(){


    const [loading, setLoading] = useState(null);


    const [showBack, setShowBack] = useState(false);
    const [showNext, setShowNext] = useState(true);
    const [buttonText, setButtonText] = useState("Next");

    const [pageIndex, setPageIndex] = useState(0);

    const types = ["Race", "Class", "Spells", "Abilities"]

    const [type, setType] = useState(types[0]);


    const [name, setName] = useState(null);
    const [race, setRace] = useState(null);
    const [charClass, setCharClass] = useState(null);
    const [spells, setSpells] = useState([]);
    const [abilities, setAbilities] = useState(null);


    const handleNext = () => {
        if(buttonText !== "Submit" && pageIndex + 1 < types.length){
            setPageIndex(pageIndex + 1);
        }else{
            handleSubmit();

        }
    }

    const handleSubmit = () => {
        if(abilities !== null){
            console.log("hell yeah!");
        }
       
        // validate submission


        console.log("to character sheet");
        // parse new character to db for user 
        // post
        

        
    }

  

    const handleBack = () => {
        if(pageIndex > 0){
            setPageIndex(pageIndex - 1);
        }
    }

    useEffect(()=> {
        setType(types[pageIndex]);
        if(pageIndex === types.length - 1 ){
            setButtonText("Submit");
            // setShowNext(false);
        }else if(pageIndex > 0){
            setShowBack(true);
            setShowNext(true);
            setButtonText("Next");

        }
        else{
            setShowNext(true);
            setButtonText("Next");
            setShowBack(false);
        }


    }, [pageIndex])

   


    // pagination
    // things 
    return(
        <div className="main">
            <NavBar />
            <div className="bgImgWrapper">
                <div className="bgImg">
                    <img src={bg2} />
                </div>
            </div>
            <div className="contentWrap">
                <div className="contentBoxWrap">
                    <div className="contentBox">
                        <div style={{display: "flex", justifyContent:"center"}}>
                            <h1 className="header">Character Creator</h1>    
                        </div>
                        <div>
                            {/* character name  + profile */}
                        </div>
                        <div>
                            <div>
                                <h3>Pick {types[pageIndex]}</h3>
                            </div>
                        </div>
                        <div style={{paddingTop: 25}}>
                            <div style={{width: '100%', display:"flex", justifyContent: "center",}}>
                                {/* for race, class, and spells */}

                            {type !== "Abilities" ?
                                <ListItem 
                                    type={type}
                                />
                                :
                                <AbilityScore abilities={abilities} setAbilities={setAbilities} />  
                            }

                            </div>

                        </div>

                        <div>


                        
                        <div style={{paddingTop: 10, 
                                    display: 'flex', 
                                    flexDirection:'row', 
                                    position: 'relative', 
                                    justifyContent: 'space-between', 
                            }}>
                            <div style={{position: 'relative', }}>
                                {showBack ?
                                    <LandingButton 
                                        radius={2}
                                        color={"#480355"}
                                        text={"Back"}
                                        borderColor={"black"}
                                        borderWidth={2}
                                        size={100}
                                        onPress={handleBack}
                                       
                                    />
                                    : null}
                            </div>

                            <div style={{position: 'relative', }}>
                                {showNext ? 
                                    <LandingButton 
                                        radius={2}
                                        color={"#480355"}
                                        text={buttonText}
                                        borderColor={"black"}
                                        borderWidth={2}
                                        size={100}
                                        onPress={handleNext}
                                    />
                                    : null}
                            </div>
                            
                        </div>
                        </div>
                        

                       
                    </div>

                
                </div>
                
            </div>
           
        </div>
    )
}

export default CharacterCreator;