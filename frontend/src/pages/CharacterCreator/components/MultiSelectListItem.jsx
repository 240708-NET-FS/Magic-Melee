import React, {useState, useEffect} from "react";
import ComponentStyles from "../../../Styles/ComponentStyles.css";



const MultiSelectListItem = ({id, type, name, object, picked, setPicked}) => {

    const [focus, setFocus] = useState(false);

    useEffect(()=> {
        console.log(object);
    }, [])


    const handlePress = () => {
        setFocus(!focus);
        handleSpellList();
    }

    const handleSpellList = () => {
        if(picked){
            if(picked.filter(p => p === id).length === 0){
                let temp = picked.splice();
                temp.push(id);
                setPicked(temp);

            }else{
                setPicked(picked.filter(p=> p !== id));
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