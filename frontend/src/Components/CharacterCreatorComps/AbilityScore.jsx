import React, { useEffect, useState } from "react";
import AbilityScoreBox from "./AbilityScoreBox";
import postAbilityScores from "../../utilities/api/postAbilityScore";


const AbilityScore = (props) => {
    const abs = ["str", "dex", "con", "int", "wis", "cha"]

    const scoreOpts = [8, 10, 12, 13, 14, 15]
    const [options, setOptions] = useState([8, 10, 12, 13, 14, 15]);

    // const [scorePicked, setScorePicked] = useState({name: "", score: null});
    const [strPicked, setStrPicked] = useState(null);
    const [dexPicked, setDexPicked] = useState(null);
    const [conPicked, setConPicked] = useState(null);
    const [intPicked, setIntPicked] = useState(null);
    const [wisPicked, setWisPicked] = useState(null);
    const [chaPicked, setChaPicked] = useState(null);

    const [strValid, setStrValid] = useState(false);
    const [dexValid, setDexValid] = useState(false);
    const [conValid, setConValid] = useState(false);
    const [intValid, setIntValid] = useState(false);
    const [wisValid, setWisValid] = useState(false);
    const [chaValid, setChaValid] = useState(false);


    const [scores, setScores] = useState(props.abilities);

    useEffect(()=> {
        if(validateScores()){
            // console.log("hell yeah");
            props.setAbilities({
                str: parseInt(strPicked),
                dex: parseInt(dexPicked),
                con: parseInt(conPicked),
                int: parseInt(intPicked),
                wis: parseInt(wisPicked),
                cha: parseInt(chaPicked)
                
        })
            try{
                
                postAbilityScores(props.abilities).then(x => props.setAbilities(x));
                console.log(props.abilities);
                
            }catch(error){
                console.error(error);
            }

           
        }else{
            console.log("Oh no!");
        }
      
    }, [strPicked, dexPicked, conPicked, intPicked, wisPicked, chaPicked])
    

    const validateScores = () => {
        return strValid && dexValid && conValid && intValid && wisValid && chaValid;

    }

    

    return(
        <div >
            <div style={{flexDirection: 'row', display: 'flex', justifyContent: 'space-between', flexWrap:'wrap'}}>
                <div style={{padding: 5}}>
                    <AbilityScoreBox 
                    name={"STR"} 
                    scorePicked={strPicked} 
                    setScorePicked={setStrPicked} 
                    options={options}
                    valid={strValid}
                    setValid={setStrValid}
                    />
                </div>
                <div style={{padding: 5}}>
                    <AbilityScoreBox 
                    name={"DEX"} 
                    scorePicked={dexPicked} 
                    setScorePicked={setDexPicked} 
                    options={options}
                    valid={dexValid}
                    setValid={setDexValid}
                    />
                </div>
                <div style={{padding: 5}}>
                    <AbilityScoreBox 
                    name={"CON"} 
                    scorePicked={conPicked} 
                    setScorePicked={setConPicked} 
                    options={options}
                    valid={conValid}
                    setValid={setConValid}
                    />
                </div>
                <div style={{padding: 5}}>
                    <AbilityScoreBox 
                    name={"INT"} 
                    scorePicked={intPicked} 
                    setScorePicked={setIntPicked} 
                    options={options}
                    valid={intValid}
                    setValid={setIntValid}
                    />
                </div>
                <div style={{padding: 5}}>
                    <AbilityScoreBox 
                    name={"WIS"} 
                    scorePicked={wisPicked} 
                    setScorePicked={setWisPicked} 
                    options={options}
                    valid={wisValid}
                    setValid={setWisValid}
                    />
                </div>
                <div style={{padding: 5}}>
                    <AbilityScoreBox 
                    name={"CHA"} 
                    scorePicked={chaPicked} 
                    setScorePicked={setChaPicked} 
                    options={options}
                    valid={chaValid}
                    setValid={setChaValid}
                    />
                </div>
            </div>
        </div>

    )
}

export default AbilityScore;