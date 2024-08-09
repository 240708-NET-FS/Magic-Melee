import React, { useState } from "react";
import LandingButton from "../Components/LandingComps/LandingButton";
import { useNavigate } from "react-router-dom";
import bg2 from "../Assets/m&mbg2.jpg";
import LandingStyles from "../Styles/LandingStyles.css";
import LandingModal from "../Components/LandingComps/LandingModal";
import { Alert } from "react-native-web";
function Landing() {
  const [open, setOpen] = useState(false);
  const [content, setContent] = useState("");

  // make type whatever
  const [loginCreds, setLoginCreds] = useState({ username: "", password: "" });
  const [newAcc, setNewAcc] = useState({
    fName: "",
    lName: "",
    username: "",
    password: "",
  });

  const navigate = useNavigate();

  const onPressGuest = () => {
    //     navigate to Home as guest
    console.log("hello guest");
    navigate("/home");
  };

  const onPressCreate = () => {
    setContent("Create Account");
    setOpen(true);
    console.log("hello new user");
  };
  const onPressLogin = () => {
    setContent("Login");
    setOpen(true);

    // console.log("hello old user");
  };

  const handleClose = () => {
    setOpen(false);
  };
  const handleSubmit = (params) => {
    //     validate form submission by content type (create account or login)
    console.log(loginCreds);
    if (content == "Login") {
      // validate things!!!
      if (loginCreds.username == null || loginCreds.password == null) {
        Alert.alert("Invalid credentials! Please reenter information!");
      } else {
        setOpen(false);
        // route to actual user home
        navigate("/home");
      }
    } else {
      // validate for new account!!
    }
  };
  return (
    <div className="landing-body">
      <div>
        <div>
          <div className="bgImgWrapper">
            <img src={bg2} width={"100%"} className="bgImg" />
          </div>
        </div>

        <div className="titleWrapper">
          <div>
            <h1 className="title">Magic & Melee</h1>
            <p style={{ fontStyle: "italic" }}>Your Adventure awaits!</p>
            <div className="buttonWrapper">
              <div className="button-row">
                <LandingButton
                  radius={4}
                  color={"black"}
                  text={"Login"}
                  borderColor={"#90FCF9"}
                  borderWidth={2}
                  size={250}
                  onPress={onPressLogin}
                />
                <LandingButton
                  radius={4}
                  color={"black"}
                  text={"Create Account"}
                  borderColor={"#90FCF9"}
                  borderWidth={2}
                  size={250}
                  onPress={onPressCreate}
                />
                <LandingButton
                  radius={4}
                  color={"black"}
                  text={"Continue As Guest"}
                  borderColor={"#90FCF9"}
                  borderWidth={2}
                  size={250}
                  onPress={onPressGuest}
                />
              </div>
            </div>

            <div></div>
          </div>
        </div>
        <LandingModal
          open={open}
          setOpen={setOpen}
          handleClose={handleClose}
          handleSubmit={handleSubmit}
          content={content}
          loginCreds={loginCreds}
          setLoginCreds={setLoginCreds}
          newAcc={newAcc}
          setNewAcc={setNewAcc}
        />
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
