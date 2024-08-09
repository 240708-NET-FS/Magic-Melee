import React from "react";
import Box from "@mui/material/Box";
import LandingButton from "../Components/LandingComps/LandingButton";
import { useNavigate } from "react-router-dom";
import bg1 from "../Assets/m&mbg1.jpg";
import LandingStyles from "../Styles/LandingStyles.css";
function Landing() {
  const navigate = useNavigate();

  const onPressGuest = () => {
    //     navigate to Home as guest
    console.log("hello guest");
    navigate("/home");
  };

  const onPressCreate = () => {
    console.log("hello new user");
  };

  const onPressLogin = () => {
    console.log("hello old user");
  };
  return (
    <div>
      <div style={{ padding: 75 }}>
        <h1>Magic & Melee</h1>
        <div>
          <LandingButton
            radius={1}
            color={"#7634bb"}
            text={"Login"}
            size={200}
            onPress={onPressLogin}
          />
          <LandingButton
            radius={1}
            color={"black"}
            text={"Create Account"}
            size={200}
            borderColor={"#7634bb"}
            borderWidth={2}
            onPress={onPressCreate}
          />
          <LandingButton
            radius={1}
            color={"#8b9a9d"}
            text={"Continue As Guest"}
            size={200}
            onPress={onPressGuest}
          />
        </div>
      </div>
    </div>
    // change to be half&half

    // <div>
    //     <div className={"bgImgContainer"} style={{position: 'absolute'}}>
    //         <img src={bg1} className={"bgImg"}/>
    //     </div>
    //
    //
    //     <div style={{padding: 75}}>
    //         <div  style={{position: 'absolute'}}>
    //             <h1>Magic & Melee</h1>
    //         </div>
    //         {/*<div className={"landing-img-overlay"} >*/}
    //         {/*    <div style={{position: 'absolute', right: 15, width: '45%', opacity: 1}}>*/}
    //                     <div>
    //                         <div>
    //                             {/*<Box*/}
    //                             {/*    sx={{*/}
    //                             {/*        height: '100%',*/}
    //                             {/*        // width: '45%',*/}
    //                             {/*        // height: '60%',*/}
    //                             {/*        // width: '35%',*/}
    //                             {/*        // borderRadius: 5,*/}
    //                             {/*        bgcolor: 'black',*/}
    //                             {/*        // opacity: '75%',*/}
    //                             {/*        padding: 10,*/}
    //                             {/*        alignItems: 'center'*/}
    //
    //                             {/*    }}*/}
    //                             {/*    component="section"*/}
    //
    //                             {/*>*/}
    //                             {/*    <div>*/}
    //                             {/*        <h1 style={{color: '#7634bb'}}>Magic & Melee</h1>*/}
    //
    //                             {/*        <div>*/}
    //                             {/*            /!*<p style={{color: 'darkblue'}}>Basic Box</p>*!/*/}
    //                             {/*        </div>*/}
    //                             {/*        <div>*/}

    //                             {/*        </div>*/}
    //
    //                             {/*    </div>*/}
    //
    //                             {/*</Box>*/}
    //
    //                         </div>
    //
    //
    //
    //         </div>
    //     </div>
    // </div>
  );
}

export default Landing;
