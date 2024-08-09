import React from 'react';
import {Button} from "@mui/material";


class CharacterCard extends React.Component{
    render(){
        return(
            <Button
                sx={{
                    color: 'white',
                    textTransform: "none"

        
                }}
                onClick={this.props.onPress}
                
            >
                <div className='cardBase'>
                    <div className='card-base2'>
                        <div>
                            {/* <div class="class-bg">

                            </div> */}
                            {/* <p>It's a card</p> */}

                        </div>
                        <div>
                            <div className='card-bottomWrapper'>
                                <div className="card-bottom">
                                        <div style={{paddingLeft: 5}}>
                                            <div>
                                                <p style={{fontSize: 18, fontWeight: "bold", margin: 0, paddingTop: 5}}>Character Name</p>
                                                <p style={{margin: 0}}>Level # Class</p>

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
}

export default CharacterCard;