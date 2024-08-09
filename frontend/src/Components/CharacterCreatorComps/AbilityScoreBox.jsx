import React, {useState, useEffect} from "react";
import ComponentStyles from "../../Styles/ComponentStyles.css";

const AbilityScoreBox = (props) => {
    let n = props.name;

    const scoreOpts = [8, 10, 12, 13, 14, 15]

    const [scoreOn, setScoreOn] = useState(null);


    useEffect(()=> {
        if(props.scorePicked && props.scorePicked !== ""){
            if(props.scorePicked > 20 || props.scorePicked < 1){
                document.getElementById(n).style.color = 'red';
                props.setValid(false);

            }else{
                document.getElementById(n).style.color = 'black';
                props.setValid(true);
                
            }
           

        }
        
    }, [props.scorePicked])
    

    return(
        <div className="asBox">
            <p style={{fontSize: 22}}>{n}</p>
            <div>
                <input id={n}
                    type="number"
                    min="1"
                    max="20"
                    className="asTextBox"
                    onChange={e => props.setScorePicked(e.target.value)}
                    />
            
            </div>
        </div>
    )

}

export default AbilityScoreBox;


