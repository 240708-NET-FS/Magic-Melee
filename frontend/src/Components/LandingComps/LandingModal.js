import React from 'react';
import {Modal} from "@mui/material";
import Box from "@mui/material/Box";
import LandingButton from "./LandingButton";
import ComponentStyles from "../../Styles/ComponentStyles.css";

class LandingModal extends React.Component{
    render(){
        return(
            <Modal
                open={this.props.open}
                onClose={this.props.handleClose}
                sx={{
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'center'
                }}
            >
                <Box
                    width={400}
                    height={"65%"}
                    sx={{
                        borderRadius: 15,
                        bgcolor: '#9d84c4',
                        padding: 5,
                        display: 'flex',
                        // alignItems: 'center',
                        justifyContent: 'center'
                    }}
                >
                    <div>
                        <h2>{this.props.content}</h2>
                        {this.props.content === "Login"
                            ?
                            <div>
                                <form onSubmit={this.props.handleSubmit}>
                                    <div style={{paddingBottom: 10}}>

                                        <input className="textBox" type="text" placeholder={"Enter Username"}/>
                                    </div>

                                    <div>

                                        <input className="textBox" type="text" placeholder={"Enter Password"}/>
                                    </div>


                                </form>


                            </div> :
                            <div>
                                <form onSubmit={this.props.handleSubmit}>
                                    <div style={{
                                        backgroundColor: '#241b31',
                                        opacity: .5,
                                        borderRadius: 15,
                                        padding: 20,
                                        alignItems: 'center',
                                        position: "relative"
                                    }}>
                                        <div style={{paddingBottom: 10}}>
                                            <input className="textBox" type="text" placeholder={"Enter First Name"}/>
                                        </div>
                                        <div style={{paddingBottom: 10}}>
                                            <input className="textBox" type="text" placeholder={"Enter Last Name"}/>
                                        </div>
                                    </div>

                                    <div style={{paddingTop: 10}}>
                                        <div style={{
                                            backgroundColor: '#241b31',
                                            opacity: .5,
                                            borderRadius: 15,
                                            padding: 20,
                                            alignItems: 'center',
                                            position: "relative"
                                        }}>

                                            <div style={{paddingBottom: 10}}>

                                                <input className="textBox" type="text" placeholder={"Enter Username"}/>
                                            </div>

                                            <div>
                                                <input className="textBox" type="text" placeholder={"Enter Password"}/>
                                            </div>

                                        </div>

                                    </div>
                                </form>


                            </div>

                        }
                        <div style={{position: 'relative', left: 50, margin: "auto", paddingTop: 25}}>
                            <div>
                                <LandingButton text={"Submit"} color={"#480355"} borderWidth={"none"} radius={4}
                                               size={200} onPress={this.props.handleSubmit}/>
                            </div>
                        </div>


                    </div>


                </Box>

            </Modal>
        )

    }

}

export default LandingModal;