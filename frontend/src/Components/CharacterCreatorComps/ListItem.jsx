import React from "react";
import ComponentStyles from "../../Styles/ComponentStyles.css";

class ListItem extends React.Component{

    // props change base on type (race or class)

    // new content on pagination

    render(){
        return(
            <div className="listItemBase">
                <div className="listItem">
                    <div className="listContentWrap">
                        <div className="listImg" />
                        <div style={{paddingLeft: 5}}>
                            <h4>{this.props.type}</h4>
                        </div>

                    </div>
                   
                </div>

            </div>
        )
    }
}

export default ListItem;