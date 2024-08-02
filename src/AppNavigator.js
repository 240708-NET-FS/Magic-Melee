import React from 'react';
import {Link} from 'react-router-dom';

const AppNavigator = () => {
    return(
        <nav>
            <ul>
                <li>
                    <Link to={"/"}>Landing</Link>
                </li>
                <li>
                    <Link to={"/home"}>Home</Link>
                </li>
            </ul>
        </nav>
    )
}

export default AppNavigator;