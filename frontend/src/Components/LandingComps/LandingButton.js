import React from 'react';
import {Button} from "@mui/material";


// perhaps include activity indicator
class LandingButton extends React.Component {
        render() {
            return (
                <div style={{paddingBottom: 10}}>
                    <Button variant="text"
                            sx={{
                                borderRadius: this.props.radius,
                                bgcolor: this.props.color,
                                width: this.props.size,
                                borderColor: this.props.borderColor,
                                border: this.props.borderWidth
                            }}
                            onClick={this.props.onPress}

                    >
                        <div>
                            <p style={{color: 'white'}}>{this.props.text}</p>
                        </div>
                    </Button>

                </div>
            )
        }

}

export default LandingButton;