import React, {useState, useEffect} from "react";
import ComponentStyles from "../../Styles/ComponentStyles.css";



const MultiSelectListItem = ({id, type, name, object, picked,setPicked}) => {

    const [focus, setFocus] = useState(false);

    // useEffect(()=> {
    //     if(picked){
    //         picked.name === name ? setFocus(true) : setFocus(false);
    //     }
    // }, [picked])

    useEffect(()=> {

    }, [picked])

    const handlePress = () => {
        setPicked([...picked, object]);
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