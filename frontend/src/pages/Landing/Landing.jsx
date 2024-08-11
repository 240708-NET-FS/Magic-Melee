import React, { useState } from "react";
import LandingButton from "../../Components/LandingComps/LandingButton";
import { useNavigate } from "react-router-dom";
import bg2 from "../../Assets/m&mbg2.jpg";
import LandingStyles from "../../Styles/LandingStyles.css";
// import LandingModal from "../../Components/LandingComps/LandingModal";

import LoginModal from "./components/LoginModal"

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
    navigate("/home/user");
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
    console.log(loginCreds);
    if (content == "Login") {
      // validate things!!!
      if (loginCreds.username == null || loginCreds.password == null) {
        Alert.alert("Invalid credentials! Please reenter information!");
      } else {
        setOpen(false);
        // route to actual user home
        navigate("/home/user");
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
        <LoginModal
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
   
  );
}

export default Landing;
