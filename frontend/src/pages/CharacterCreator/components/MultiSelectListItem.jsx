import React, {useState, useEffect} from "react";
import ComponentStyles from "../../../Styles/ComponentStyles.css";



const MultiSelectListItem = ({id, type, name, object, picked,setPicked}) => {

    const [focus, setFocus] = useState(false);

    // useEffect()


    const handlePress = () => {
        setFocus(!focus);
        handleSpellList();
    }

    const handleSpellList = () => {
        if(picked){
            if(picked.filter(p => p.spellName === name).length === 0){
                setPicked([...picked, object]);
            }else{
                setPicked(picked.filter(p=> p.spellName !== name));
            }
        }


    }

    return(
        <button className="listItemBase" onClick={handlePress}>
            <div className="listItem" style={focus ? {backgroundColor: '#3f1b53'}: null}>
                <div className="listContentWrap">
                    <div className="listImg" />
                    <div style={{paddingLeft: 5}}>
                        <h4>{name}</h4>
                    </div>

                </div>
            
            </div>

    </button>

    )

}

export default MultiSelectListItem;