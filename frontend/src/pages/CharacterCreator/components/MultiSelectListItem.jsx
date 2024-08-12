import React, {useState, useEffect} from "react";
import ComponentStyles from "../../../Styles/ComponentStyles.css";
import { postCharacterSpell } from "../../../utilities/api";
import deleteCharacterSpell from "../../../utilities/api";



const MultiSelectListItem = ({id, type, name, object, picked, setPicked}) => {

    const [focus, setFocus] = useState(false);

    // useEffect(()=> {
    //     console.log(object);
    // }, [])


    useEffect(()=> {
        handleSpellList();
    }, [focus])


    const handlePress = () => {
        setFocus(!focus);
    }

    const handleSpellList = () => {
        if(picked){
            if(picked.filter(p => p=== id).length == 0){
                try{
                    postCharacterSpell()
                }catch(error){
                    console.error(error)
                }
            }

            // if(picked.filter(p => p === id).length === 0){
            //     let temp = picked.slice();
            //     temp.push(id);
            //     setPicked(temp);

            // }else{
            //     setPicked(picked.filter(p=> p !== id));
            // }
        }
        // console.log(picked);
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