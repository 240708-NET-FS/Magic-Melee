import React from 'react';
import {Button} from "@mui/material";


class LandingButton extends React.Component {
        render() {
            return (
                <div style={{paddingBottom: 10}}>
                    <Button variant="text"
                            sx={{
                                borderRadius: this.props.radius,
                                bgcolor: this.props.color,
                                width: this.props.size,
                                borderColor: 'secondary.main',
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