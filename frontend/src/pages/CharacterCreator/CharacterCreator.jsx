import React, { useEffect, useRef, useState } from "react";
import CharacterCreatorStyles from "../../Styles/CharacterCreatorStyles.css";
import bg2 from "../../Assets/m&mbg2.jpg"
import ListItem from "../../Components/CharacterCreatorComps/ListItem";
import MultiSelectListItem from "./components/MultiSelectListItem";
import LandingButton from "../../Components/LandingComps/LandingButton";
import NavBar from "../../Components/NavBar";
import AbilityScore from "../../Components/CharacterCreatorComps/AbilityScore";


import getAllRaces from "../../utilities/api/getAllRaces";
import getAllClasses from "../../utilities/api/getAllClasses";
// import getClassSpells from "../../utilities/api/getAllSpells";
import getAllSpells from "../../utilities/api/getAllSpells";
import postCharacter from "../../utilities/api/postCharacter";
import postAbilityScores from "../../utilities/api/postAbilityScore";

import { useNavigate } from "react-router-dom";
// import getClassSpells from "../../utilities/api/getClassSpells";


function CharacterCreator(){


    const [loading, setLoading] = useState(true);


    const [showBack, setShowBack] = useState(false);
    const [showNext, setShowNext] = useState(true);
    const [buttonText, setButtonText] = useState("Next");

    const [pageIndex, setPageIndex] = useState(0);

    const types = ["Race", "Class", "Spells", "Abilities"]

    const [type, setType] = useState(types[0]);


    const [name, setName] = useState(null);
    const [level, setLevel] = useState(1);
    const [race, setRace] = useState(null);
    const [charClass, setCharClass] = useState(null);
    const [charSpells, setCharSpells] = useState([]);

    const [spells, setSpells] = useState([]);
    const [abilities, setAbilities] = useState(null);

    const [picked, setPicked] = useState(null);
    const [pickedList, setPickedList] = useState([]);

    const [races, setRaces] = useState([]);
    const [classes, setClasses] = useState([]);

    const navigate = useNavigate();



    useEffect(()=> {
        fetchRaces();
        fetchClasses();
        setLoading(false);
    }, [])


    useEffect(()=> {
        if(types[pageIndex] === "Race"){
            setRace(picked);
        }else if(types[pageIndex] === "Class"){
            setCharClass(picked);
        }else{
            setCharSpells(picked);
        }

    }, [picked])


    const fetchRaces = async () => {
        try{
            let r = await getAllRaces();
            setRaces(r);

        }catch(error){
            console.error(error);
        }
    }

    const fetchClasses = async () => {
        try{
            let c = await getAllClasses();
            setClasses(c);

        }catch(error){
            console.error(error);
        }
    }
    const handleNext = () => {
        if(buttonText !== "Submit" && pageIndex + 1 < types.length){
            setPageIndex(pageIndex + 1);
        }else{
            handleSubmit();

        }
    }

    const handleSubmit = () => {
        if(abilities !== null){
            // postAbilityScores(abilities);

        //     console.log("hell yeah!");   
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


    useEffect(()=> {
        if(type ==="Spells" && charClass){
            fetchSpells(charClass.name);  
        }
    }, [type, charClass])


    const fetchSpells = async(className) => {
        try{
            let res = await getAllSpells(className);
            setSpells(res);
            console.log(spells)
        }catch(error){
            console.log(error);
        }
    }

    const mapRaces = races.map((r, index) => (
        <div style={{paddingBottom: 7}}>
            <ListItem 
                id={r.characterRaceId} 
                type={"race"} 
                name={r.name} 
                object={r}
                picked={picked} 
                setPicked={setPicked}/>
        </div>
    ))
   
    const mapClasses = classes.map((c, index) => (
        <div style={{paddingBottom: 7}}>
            <ListItem id={c.characterClassId} type={"class"} name={c.name} object={c} picked={picked} setPicked={setPicked} />
        </div>
    ))

    const mapSpells = spells.map((s, index) =>(
        <div style={{paddingBottom: 7}}>
            <MultiSelectListItem id={s.spellId} type={"spell"} name={s.spellName} object={s} picked={pickedList} setPicked={setPickedList} />
        </div>  

    ));

    useEffect(()=> {
        if(level && !loading){
            if(level < 1 || level > 20){
                document.getElementById("level").style.color = 'red';
            }else{
                document.getElementById("level").style.color = 'black';
            }
        }
      
    }, [level])

    return(
        loading ? null :
        <div className="main">
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
                            <div style={{paddingTop: 20}}>
                                <div style={{display: 'flex', flexDirection: 'row', justifyContent: 'space-evenly', }}>
                                    
                                    <div>
                                        <input id="name" type="text" className="textBox" placeholder="Enter Character Name:" style={{color: 'black'}} onChange={e => setName(e.target.value)}/>
                                    </div>
                                    <div>
                                        <label for="level">Level #:</label>
                                        <input id="level" type="number" className="asTextBox" min={1} max={20} onChange={e => setLevel(e.target.value)} value={level} style={{color: 'black'}}/> 
                                    </div>
                                </div>
                                
                            
                               
                            </div>
                        </div>
                        <div>
                            <div>
                                <h3>Pick {types[pageIndex]}</h3>
                            </div> 
                        </div>
                        <div style={{paddingTop: 25, display: 'flex' }}>
                            <div style={{width: '100%',alignItems: 'center', justifyContent: 'center'}}>
                                <div>
                                    {type === "Race" ? mapRaces
                                    : type === "Class" ? mapClasses

                                    : type === "Spells"? mapSpells
                                    :  <AbilityScore abilities={abilities} setAbilities={setAbilities} />  }
                                </div>

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