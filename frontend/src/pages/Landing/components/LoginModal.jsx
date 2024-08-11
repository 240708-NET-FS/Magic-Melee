import React, {useEffect, useState} from 'react';
import {Modal} from "@mui/material";
import Box from "@mui/material/Box";
import LandingButton from "../../../Components/LandingComps/LandingButton";
import ComponentStyles from "../../../Styles/ComponentStyles.css";
import { useAuth } from '../../../provider/authProvider';
import { useNavigate } from 'react-router-dom';
import getUsers from "../../../utilities/api/getUsers";

const LoginModal = ({open,handleClose, handleSubmit,content, loginCreds, setLoginCreds}) => {

    const navigate = useNavigate();
    const [users, setUsers] = useState([]);


    useEffect(()=> {
        fetchUsers();
    
        
    }, [])


    const fetchUsers = async() => {
        try{
            const res = await getUsers();
            setUsers(res);
        }catch(error){
            console.error(error);
        }
    }


    const handleLogin = async() => {
        console.log(loginCreds);


        // setToken("this is a test token");
        navigate("/home/user");
    };




        return(
            <Modal
                open={open}
                onClose={handleClose}
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
                        <h2>{content}</h2>
                        {content === "Login"
                            ?
                            <div>
                                <form onSubmit={handleSubmit}>
                                    <div style={{paddingBottom: 10}}>

                                        <input className="textBox" type="text" placeholder={"Enter Username"} value={loginCreds.username} onChange={e => setLoginCreds({...loginCreds, username: e.target.value})}/>
                                    </div>

                                    <div>

                                        <input className="textBox" type="text" placeholder={"Enter Password"} value={loginCreds.password} onChange={e => setLoginCreds({...loginCreds, password: e.target.value})}/>
                                    </div>

                                </form>


                            </div> :
                            <div>
                                <form onSubmit={handleSubmit}>
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

                                            {/* <div style={{paddingBottom: 10}}>
                                                <input className="textBox" type="text" placeholder={"Enter Username"} value={loginCreds.username} onChange={e => this.props.setLoginCreds({username: e.target.value, password: null})}/>
                                            </div>

                                            <div>
                                                <input className="textBox" type="text" placeholder={"Enter Password"}/>
                                            </div> */}

                                        </div>

                                    </div>
                                </form>


                            </div>

                        }
                        <div style={{position: 'relative', left: 50, margin: "auto", paddingTop: 25}}>
                            <div>
                                <LandingButton text={"Submit"} color={"#480355"} borderWidth={"none"} radius={4}
                                               size={200} onPress={handleLogin}/>
                            </div>
                        </div>

                    </div>


                </Box>

            </Modal>
        )

    

}

export default LoginModal;